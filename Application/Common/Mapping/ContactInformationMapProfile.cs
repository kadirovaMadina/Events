using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Common.BaseEntities;
using Domain.Entities;

namespace Application.Common.Mapping;

public class ContactInformationMapProfile : Profile
{
    public ContactInformationMapProfile()
    {
        CreateMap<CreateContactInformationRequest, ContactInformation>();

        CreateMap<ContactInformation, SingleContactInformationResponse>();

        CreateMap<GetAllContactInformationsRequest, GetAllContactInformationsResponse>();

        CreateMap<UpdateContactInformationRequest, ContactInformation>();
    }
}