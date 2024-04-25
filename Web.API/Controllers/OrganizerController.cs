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
    public class OrganizerController : Controller
    {
        private readonly IBaseService<Organizer> _organizerService;
        private readonly IMapper _mapper;

        public OrganizerController(IBaseService<Organizer> organizerService, IMapper mapper)
        {
            _organizerService = organizerService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateOrganizerRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<Organizer>(request);

            var response = await _organizerService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _organizerService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleOrganizerResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _organizerService.GetAllAsync(token);

            var response = new GetAllOrganizersResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleOrganizerResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrganizerRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Organizer entity = _mapper.Map<Organizer>(request);

            await _organizerService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleOrganizerResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _organizerService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Organizer with ID {id} not found.");
        }
    }
}