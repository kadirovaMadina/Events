using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class LocationMapProfile : Profile
{
    public LocationMapProfile()
    {
        CreateMap<CreateLocationRequest, Location>();

        CreateMap<Location, SingleLocationResponse>();

        CreateMap<GetAllLocationsRequest, GetAllLocationsResponse>();

        CreateMap<UpdateLocationRequest, Location>();
    }
}