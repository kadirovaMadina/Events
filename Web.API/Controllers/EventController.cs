using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    public class EventController : Controller
    {
        private readonly IBaseService<Event> _eventService;
        private readonly IMapper _mapper;


        public EventController(IMapper mapper, IBaseService<Event> EventService)
        {
            _eventService = EventService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.EventMethod.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventRequest request, CancellationToken token)
        {
            var Event = _mapper.Map<Event>(request);

            var response = await _eventService.CreateAsync(Event, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

        }

        [HttpGet(ApiEndpoints.EventMethod.Get)]
        public async Task<IActionResult> Get(Guid id, CancellationToken token)
        {
            var EventExist = await _eventService.GetAsync(id);

            if (EventExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleEventResponse>(EventExist);

            return response == null ? NotFound() : Ok(response);
        }
    }
}
