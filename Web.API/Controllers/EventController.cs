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
    public class EventController : Controller
    {
        private readonly IBaseService<Event> _eventService;
        private readonly IMapper _mapper;

        public EventController(IBaseService<Event> eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventRequest request, CancellationToken token)
        {
            var entity = _mapper.Map<Event>(request);

            var response = await _eventService.CreateAsync(entity, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var entityExist = await _eventService.GetAsync(id);

            if (entityExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleEventResponse>(entityExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.EventMethod.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var entity = await _eventService.GetAllAsync(token);

            var response = new GetAllEventsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleEventResponse>>(entity)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.EventMethod.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEventRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Event entity = _mapper.Map<Event>(request);

            await _eventService.UpdateAsync(entity, token);

            var response = _mapper.Map<SingleEventResponse>(entity);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.EventMethod.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _eventService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Event with ID {id} not found.");
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
//    public class EventController : Controller
//    {
//        private readonly IBaseService<Event> _eventService;
//        private readonly IMapper _mapper;


//        public EventController(IMapper mapper, IBaseService<Event> EventService)
//        {
//            _eventService = EventService;
//            _mapper = mapper;
//        }

//        [HttpPost(ApiEndpoints.EventMethod.Create)]
//        public async Task<IActionResult> Create([FromBody] CreateEventRequest request, CancellationToken token)
//        {
//            var Event = _mapper.Map<Event>(request);

//            var response = await _eventService.CreateAsync(Event, token);
//            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

//        }

//        [HttpGet(ApiEndpoints.EventMethod.Get)]
//        public async Task<IActionResult> Get(Guid id, CancellationToken token)
//        {
//            var EventExist = await _eventService.GetAsync(id);

//            if (EventExist == null)
//            {
//                return NotFound();
//            }

//            var response = _mapper.Map<SingleEventResponse>(EventExist);

//            return response == null ? NotFound() : Ok(response);
//        }
//    }
//}
