using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskSystemServer.Data;
using TaskSystemServer.Dtos.Account;
using TaskSystemServer.Dtos.Member;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;
using TaskSystemServer.Models;
using TaskSystemServer.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMemberRepository _memberRepo;
        private readonly TasksystemContext _context;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPrefernceRepository _prefrerenceRepo;

        public AccountController(UserManager<AppUser> userManager, IMemberRepository memberRepo, TasksystemContext context,ITokenService tokenService, SignInManager<AppUser> signInManager, IPrefernceRepository prefrerenceRepo)
        {
            _userManager = userManager;
            _memberRepo = memberRepo;
            _context = context;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _prefrerenceRepo = prefrerenceRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using(var transaction=await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var appUser= new AppUser
                    {
                        UserName=registerDto.Username,
                        Email=registerDto.EmailAddress,
                    };

                    var createdUser= await _userManager.CreateAsync(appUser, registerDto.Password); 
                    if(!createdUser.Succeeded)
                    {
                        return StatusCode(500, createdUser.Errors);
                    }

                    //Create Member
                    var member = new CreateMemberDto (){ 
                        Name = registerDto.Name,
                        Dob=registerDto.Dob,
                        Timezone=registerDto.Timezone,
                        AppUserId=appUser.Id
                    };
                    var memberModel = member.ToMemberFromCreateDto();

                    var createdMember = await _memberRepo.CreateAsync(memberModel);

                    if (createdMember == null)
                    {
                        throw new Exception("Failed to create member");
                    }

                    // Add User role
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (!roleResult.Succeeded)
                    {
                        return StatusCode(500, roleResult.Errors);
                    }

                    await transaction.CommitAsync();

                    var mem = await _memberRepo.GetByUserIdAsync(appUser.Id);

                    var prefernce = new Memberprefernce
                    {
                        MemberId=mem.MemberId
                    };
                    var memberPreference = await _prefrerenceRepo.CreateAsync(prefernce);

                    return Ok(new NewUserDto
                    {
                        EmailAddress = appUser.Email,
                        Username = registerDto.Username,
                        MemberId=mem.MemberId,
                        Token = _tokenService.CreateToken(appUser,mem.MemberId)
                    });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) { return Unauthorized("Invalid Username"); }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) { return Unauthorized("wrong username or password"); }

            var member = await _memberRepo.GetByUserIdAsync(user.Id);
            if (member == null)
            {
                // Handle the case where inst is null
                // Perhaps return an error response
                return BadRequest(user.Id);
            }

            return Ok(
                new NewUserDto
                {
                    Username = user.UserName,
                    EmailAddress = user.Email,
                    MemberId = member.MemberId,
                    Token = _tokenService.CreateToken(user,member.MemberId)
                }
                );
        }
    }
}
