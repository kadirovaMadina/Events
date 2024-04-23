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
    public class LocationController : Controller
    {
        private readonly IBaseService<Location> _locationService;
        private readonly IMapper _mapper;

        public LocationController(IBaseService<Location> locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<Location>(request);

            var response = await _locationService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _locationService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleLocationResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _locationService.GetAllAsync(token);

            var response = new GetAllLocationsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleLocationResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateLocationRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Location entity = _mapper.Map<Location>(request);

            await _locationService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleLocationResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _locationService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Location with ID {id} not found.");
        }
    }
}



//using Application.Services;
//using AutoMapper;
//using Contracts.Requests;
//using Contracts.Responses;
//using Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace Web.API.Controllers
//{
//    public class LocationController : Controller
//    {
//        private readonly IBaseService<Location> _locationService;
//        private readonly IMapper _mapper;


//        public LocationController(IMapper mapper, IBaseService<Location> LocationService)
//        {
//            _locationService = LocationService;
//            _mapper = mapper;
//        }

//        //[HttpPost(ApiEndpoints.EventMethod.Create)]
//        //public async Task<IActionResult> Create([FromBody] CreateLocationRequest request, CancellationToken token)
//        //{
//        //    var Location = _mapper.Map<Location>(request);

//        //    var response = await _locationService.CreateAsync(Location, token);
//        //    return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

//        //}

//        //[HttpGet(ApiEndpoints.EventMethod.Get)]
//        //public async Task<IActionResult> Get(Guid id, CancellationToken token)
//        //{
//        //    var LocationExist = await _locationService.GetAsync(id);

//        //    if (LocationExist == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var response = _mapper.Map<SingleLocationResponse>(LocationExist);

//        //    return response == null ? NotFound() : Ok(response);
//        //}
//    }
//}
