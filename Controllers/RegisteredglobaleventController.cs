using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Dtos.Registeredglobalevent;
using TaskSystemServer.Extentions;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredglobaleventController : ControllerBase
    {
        private readonly IRegisteredglobaleventRepository _registeredRepo;
        public RegisteredglobaleventController(IRegisteredglobaleventRepository registeredRepo)
        {
            _registeredRepo = registeredRepo;
        }

        [HttpPost("{evId}")]
        [Authorize]
        public async Task<IActionResult> AddEvent([FromRoute] int evId,CreateRegisteredglobaleventDto ev)
        {
            var memberId = User.GetMemberId();
            var createdRegEvent = await _registeredRepo.CreateAsync(ev.ToRegisteredGlobalEventFromCreate(evId,int.Parse(memberId)));
            return CreatedAtAction(nameof(GetGlobalEvent), new { id = createdRegEvent.EventId }, createdRegEvent.ToRegisteredGlobalEventDto());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGlobalEvent([FromRoute] int id)
        {
            var memberId = User.GetMemberId();
            var ev = await _registeredRepo.GetByRegisteredglobaleventIdAsync(id,int.Parse(memberId));
            if (ev == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(ev.ToRegisteredGlobalEventDto());
        }

        [HttpGet("registeredglobalevents")]
        [Authorize]
        public async Task<IActionResult> GetEvents()
        {
            var memberId = int.Parse(User.GetMemberId());
            var events = await _registeredRepo.GetByIdAsync(memberId);
            return Ok(events.Select(ev => ev.ToRegisteredGlobalEventDto()));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] UpdateRegisteredglobaleventDto ev)
        {
            var memberId = int.Parse(User.GetMemberId());
            var evRegisteredModel = await _registeredRepo.UpdateAsync(id,memberId, ev);
            if (evRegisteredModel == null)
            {
                return NotFound();
            }

            return Ok(evRegisteredModel.ToRegisteredGlobalEventDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var memberId = int.Parse(User.GetMemberId());
            var ev = await _registeredRepo.DeleteAsync(id,memberId);
            if (ev == null)
            {
                return NotFound("Registered event does not exist");
            }

            return NoContent();
        }
    }
}
