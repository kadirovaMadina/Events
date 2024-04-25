using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class SpeakerMapProfile : Profile
{
    public SpeakerMapProfile()
    {
        CreateMap<CreateSpeakerRequest, Speaker>();

        CreateMap<Speaker, SingleSpeakerResponse>();

        CreateMap<GetAllSpeakersRequest, GetAllSpeakersResponse>();

        CreateMap<UpdateSpeakerRequest, Speaker>();
    }
}