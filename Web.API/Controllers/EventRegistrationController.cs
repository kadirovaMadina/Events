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
    public class EventRegistrationController : Controller
    {
        private readonly IBaseService<EventRegistration> _eventRegistrationService;
        private readonly IMapper _mapper;

        public EventRegistrationController(IBaseService<EventRegistration> eventRegistrationService, IMapper mapper)
        {
            _eventRegistrationService = eventRegistrationService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventRegistrationRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<EventRegistration>(request);

            var response = await _eventRegistrationService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _eventRegistrationService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleEventRegistrationResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _eventRegistrationService.GetAllAsync(token);

            var response = new GetAllEventRegistrationsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleEventRegistrationResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventRegistrationRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            EventRegistration entity = _mapper.Map<EventRegistration>(request);

            await _eventRegistrationService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleEventRegistrationResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _eventRegistrationService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"EventRegistration with ID {id} not found.");
        }
    }
}