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
    public class SponsorController : Controller
    {
        private readonly IBaseService<Sponsor> _sponsorService;
        private readonly IMapper _mapper;

        public SponsorController(IBaseService<Sponsor> sponsorService, IMapper mapper)
        {
            _sponsorService = sponsorService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSponsorRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<Sponsor>(request);

            var response = await _sponsorService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _sponsorService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleSponsorResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _sponsorService.GetAllAsync(token);

            var response = new GetAllSponsorsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleSponsorResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSponsorRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Sponsor entity = _mapper.Map<Sponsor>(request);

            await _sponsorService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleSponsorResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _sponsorService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Sponsor with ID {id} not found.");
        }
    }
}