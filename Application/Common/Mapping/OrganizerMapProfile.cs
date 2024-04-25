using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class OrganizerMapProfile : Profile
{
    public OrganizerMapProfile()
    {
        CreateMap<CreateOrganizerRequest, Organizer>();

        CreateMap<Organizer, SingleOrganizerResponse>();

        CreateMap<GetAllOrganizersRequest, GetAllOrganizersResponse>();

        CreateMap<UpdateOrganizerRequest, Organizer>();
    }
}