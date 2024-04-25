using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class ParticipantMapProfile : Profile
{
    public ParticipantMapProfile()
    {
        CreateMap<CreateParticipantRequest, Participant>();

        CreateMap<Participant, SingleParticipantResponse>();

        CreateMap<GetAllParticipantsRequest, GetAllParticipantsResponse>();

        CreateMap<UpdateParticipantRequest, Participant>();
    }
}