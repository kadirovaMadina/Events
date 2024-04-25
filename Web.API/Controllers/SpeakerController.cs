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
    public class SpeakerController : Controller
    {
        private readonly IBaseService<Speaker> _speakerService;
        private readonly IMapper _mapper;

        public SpeakerController(IBaseService<Speaker> speakerService, IMapper mapper)
        {
            _speakerService = speakerService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSpeakerRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<Speaker>(request);

            var response = await _speakerService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _speakerService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleSpeakerResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _speakerService.GetAllAsync(token);

            var response = new GetAllSpeakersResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleSpeakerResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSpeakerRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Speaker entity = _mapper.Map<Speaker>(request);

            await _speakerService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleSpeakerResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _speakerService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Speaker with ID {id} not found.");
        }
    }
}