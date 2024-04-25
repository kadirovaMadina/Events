using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class EventSponsorMapProfile : Profile
{
    public EventSponsorMapProfile()
    {
        CreateMap<CreateEventSponsorRequest, EventSponsor>();

        CreateMap<EventSponsor, SingleEventSponsorResponse>();

        CreateMap<GetAllEventSponsorsRequest, GetAllEventSponsorsResponse>();

        CreateMap<UpdateEventSponsorRequest, EventSponsor>();
    }
}