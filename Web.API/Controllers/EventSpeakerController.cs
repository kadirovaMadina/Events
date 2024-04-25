using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.API;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventSpeakerController : Controller
    {
        private readonly IBaseService<EventSpeaker> _eventSpeakerService;
        private readonly IMapper _mapper;

        public EventSpeakerController(IBaseService<EventSpeaker> eventSpeakerService, IMapper mapper)
        {
            _eventSpeakerService = eventSpeakerService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventSpeakerRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<EventSpeaker>(request);

            var response = await _eventSpeakerService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _eventSpeakerService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleEventSpeakerResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _eventSpeakerService.GetAllAsync(token);

            var response = new GetAllEventSpeakersResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleEventSpeakerResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventSpeakerRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            EventSpeaker entity = _mapper.Map<EventSpeaker>(request);

            await _eventSpeakerService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleEventSpeakerResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _eventSpeakerService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"EventSpeaker with ID {id} not found.");
        }
    }
}