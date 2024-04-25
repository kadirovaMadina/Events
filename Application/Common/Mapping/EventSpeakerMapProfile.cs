using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class EventSpeakerMapProfile : Profile
{
    public EventSpeakerMapProfile()
    {
        CreateMap<CreateEventSpeakerRequest, EventSpeaker>();

        CreateMap<EventSpeaker, SingleEventSpeakerResponse>();

        CreateMap<GetAllEventSpeakersRequest, GetAllEventSpeakersResponse>();

        CreateMap<UpdateEventSpeakerRequest, EventSpeaker>();
    }
}