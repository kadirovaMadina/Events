﻿using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class EventMapProfile : Profile
{
    public EventMapProfile()
    {
        CreateMap<CreateEventRequest, Event>();

        CreateMap<Event, SingleEventResponse>();

        CreateMap<GetAllEventsRequest, GetAllEventsResponse>();

        CreateMap<UpdateEventRequest, Event>();
    }
}