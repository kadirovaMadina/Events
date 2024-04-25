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
    public class EventSponsorController : Controller
    {
        private readonly IBaseService<EventSponsor> _eventSponsorService;
        private readonly IMapper _mapper;

        public EventSponsorController(IBaseService<EventSponsor> eventSponsorService, IMapper mapper)
        {
            _eventSponsorService = eventSponsorService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventSponsorRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<EventSponsor>(request);

            var response = await _eventSponsorService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _eventSponsorService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleEventSponsorResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _eventSponsorService.GetAllAsync(token);

            var response = new GetAllEventSponsorsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleEventSponsorResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventSponsorRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            EventSponsor entity = _mapper.Map<EventSponsor>(request);

            await _eventSponsorService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleEventSponsorResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _eventSponsorService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"EventSponsor with ID {id} not found.");
        }
    }
}