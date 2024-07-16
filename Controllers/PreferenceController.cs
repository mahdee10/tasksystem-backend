using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.Preferences;
using TaskSystemServer.Dtos.Task;
using TaskSystemServer.Extentions;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;
using TaskSystemServer.Models;

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly IPrefernceRepository _prefrerenceRepo;

        public PreferenceController(IPrefernceRepository prefrerenceRepo)
        {
            _prefrerenceRepo = prefrerenceRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPreference()
        {
            var memberId = User.GetMemberId();

            var prefernce = new Memberprefernce
            {
                MemberId = int.Parse(memberId)
            };

            var createdPreference = await _prefrerenceRepo.CreateAsync(prefernce);
            return Ok(createdPreference);

        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdatePreference([FromBody] PreferenceDto pr)
        {
            var memberId = int.Parse(User.GetMemberId());
            var preModel = await _prefrerenceRepo.UpdateAsync(memberId, pr);
            if (preModel == null)
            {
                return NotFound();
            }

            return Ok(preModel);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> myprefernces()
        {
            var memberId = int.Parse(User.GetMemberId());
            var pre = await _prefrerenceRepo.GetByIdAsync(memberId);
            if (pre == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(pre.ToPreferenceDto());
        }

    }
}
