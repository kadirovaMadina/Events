using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class SponsorMapProfile : Profile
{
    public SponsorMapProfile()
    {
        CreateMap<CreateSponsorRequest, Sponsor>();

        CreateMap<Sponsor, SingleSponsorResponse>();

        CreateMap<GetAllSponsorsRequest, GetAllSponsorsResponse>();

        CreateMap<UpdateSponsorRequest, Sponsor>();
    }
}