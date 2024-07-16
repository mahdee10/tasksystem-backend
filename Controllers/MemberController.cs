using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSystemServer.Dtos.Member;
using TaskSystemServer.Extentions;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepo;
        public MemberController(IMemberRepository memberRepository) { 
        
            _memberRepo = memberRepository;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members=await _memberRepo.GetAllAsync();
            return Ok(members.Select(m => m.ToMemberDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] int id)
        {
            var member = await _memberRepo.GetByIdAsync(id);
            if(member == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(member.ToMemberDto());
        }

        [HttpGet("getme")]
        [Authorize]
        public async Task<IActionResult> getMe()
        {
            var memberId = int.Parse(User.GetMemberId());
            var member = await _memberRepo.GetByIdAsync(memberId);
            if (member == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(member.ToMemberDto());
        }


        [HttpPost]

        public async Task<IActionResult> Post(CreateMemberDto member)
        {
            var memberModel=member.ToMemberFromCreateDto();
            var memberWithId =await _memberRepo.CreateAsync(memberModel);
            return CreatedAtAction(nameof(GetMember), new { id = memberWithId.MemberId }, memberWithId.ToMemberDto());

        }
    }
}
