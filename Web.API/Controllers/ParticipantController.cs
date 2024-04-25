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
    public class ParticipantController : Controller
    {
        private readonly IBaseService<Participant> _participantService;
        private readonly IMapper _mapper;

        public ParticipantController(IBaseService<Participant> participantService, IMapper mapper)
        {
            _participantService = participantService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateParticipantRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<Participant>(request);

            var response = await _participantService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _participantService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleParticipantResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _participantService.GetAllAsync(token);

            var response = new GetAllParticipantsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleParticipantResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateParticipantRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Participant entity = _mapper.Map<Participant>(request);

            await _participantService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleParticipantResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _participantService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Participant with ID {id} not found.");
        }
    }
}