using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.GlobalEvents;
using TaskSystemServer.Extentions;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalEventsController : ControllerBase
    {
        private readonly IGlobalEventRepository _globaleventRepo;
        public GlobalEventsController(IGlobalEventRepository globaleventRepo) {
            _globaleventRepo = globaleventRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEvent(CreateGlobalEventDto ev)
        {
            var createdEvent = await _globaleventRepo.CreateAsync(ev.ToGlobalEventFromCreate());
            return CreatedAtAction(nameof(GetGlobalEvent), new { id = createdEvent.EventId }, createdEvent.ToGlobalEventDto());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGlobalEvent([FromRoute] int id)
        {
            var ev = await _globaleventRepo.GetByEventIdAsync(id);
            if (ev == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(ev.ToGlobalEventDto());
        }

        [HttpGet("globalevents")]
        [Authorize]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _globaleventRepo.GetByIdAsync();
            return Ok(events.Select(ev => ev.ToGlobalEventDto()));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] CreateGlobalEventDto ev)
        {

            var eventModel = await _globaleventRepo.UpdateAsync(id, ev);
            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel.ToGlobalEventDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ev = await _globaleventRepo.DeleteAsync(id);
            if (ev == null)
            {
                return NotFound("Event does not exist");
            }

            return NoContent();
        }
    }
}
