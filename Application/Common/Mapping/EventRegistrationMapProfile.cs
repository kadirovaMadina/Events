using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class EventRegistrationMapProfile : Profile
{
    public EventRegistrationMapProfile()
    {
        CreateMap<CreateEventRegistrationRequest, EventRegistration>();

        CreateMap<EventRegistration, SingleEventRegistrationResponse>();

        CreateMap<GetAllEventRegistrationsRequest, GetAllEventRegistrationsResponse>();

        CreateMap<UpdateEventRegistrationRequest, EventRegistration>();
    }
}