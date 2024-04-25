using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Common.BaseEntities;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.API;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactInformationController : Controller
    {
        private readonly IBaseService<ContactInformation> _contactInformationService;
        private readonly IMapper _mapper;

        public ContactInformationController(IBaseService<ContactInformation> contactInformationService, IMapper mapper)
        {
            _contactInformationService = contactInformationService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateContactInformationRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<ContactInformation>(request);

            var response = await _contactInformationService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _contactInformationService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleContactInformationResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _contactInformationService.GetAllAsync(token);

            var response = new GetAllContactInformationsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleContactInformationResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateContactInformationRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            ContactInformation entity = _mapper.Map<ContactInformation>(request);

            await _contactInformationService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleContactInformationResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _contactInformationService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"ContactInformation with ID {id} not found.");
        }
    }
}