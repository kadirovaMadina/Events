using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class EventOrganizerMapProfile : Profile
{
    public EventOrganizerMapProfile()
    {
        CreateMap<CreateEventOrganizerRequest, EventOrganizer>();

        CreateMap<EventOrganizer, SingleEventOrganizerResponse>();

        CreateMap<GetAllEventOrganizersRequest, GetAllEventOrganizersResponse>();

        CreateMap<UpdateEventOrganizerRequest, EventOrganizer>();
    }
}