using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Extentions;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;
using TaskSystemServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepo;
        public EventController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        [HttpGet("myevents")]
        [Authorize]
        public async Task<IActionResult> GetEvents()
        {
            var mamberId = User.GetMemberId();
            var events = await _eventRepo.GetByIdAsync(int.Parse(mamberId));
            return Ok(events.Select(m => m.ToEventDto()));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEvent(CreateEventDto ev)
        {
            var mamberId = User.GetMemberId();
            var createdEvent = await _eventRepo.CreateAsync(ev.ToEventFromCreate(int.Parse(mamberId)));
            return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.EventId }, createdEvent.ToEventDto());
            
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var ev = await _eventRepo.GetByEventIdAsync(id);
            if (ev == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(ev.ToEventDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] UpdateEventDto ev)
        {

            var eventModel = await _eventRepo.UpdateAsync(id, ev);
            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel.ToEventDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ev = await _eventRepo.DeleteAsync(id);
            if (ev == null)
            {
                return NotFound("Event does not exist");
            }

            return NoContent();
        }

    }
}
