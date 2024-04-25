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
    public class EventOrganizerController : Controller
    {
        private readonly IBaseService<EventOrganizer> _eventOrganizerService;
        private readonly IMapper _mapper;

        public EventOrganizerController(IBaseService<EventOrganizer> eventOrganizerService, IMapper mapper)
        {
            _eventOrganizerService = eventOrganizerService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventOrganizerRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<EventOrganizer>(request);

            var response = await _eventOrganizerService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _eventOrganizerService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleEventOrganizerResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _eventOrganizerService.GetAllAsync(token);

            var response = new GetAllEventOrganizersResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleEventOrganizerResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventOrganizerRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            EventOrganizer entity = _mapper.Map<EventOrganizer>(request);

            await _eventOrganizerService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleEventOrganizerResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _eventOrganizerService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"EventOrganizer with ID {id} not found.");
        }
    }
}