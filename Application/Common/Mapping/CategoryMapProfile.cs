using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class CategoryMapProfile : Profile
{
    public CategoryMapProfile()
    {
        CreateMap<CreateCategoryRequest, EventCategory>();

        CreateMap<EventCategory, SingleCategoryResponse>();

        CreateMap<GetAllCategoriesRequest, GetAllCategoriesResponse>();

        CreateMap<UpdateCategoryRequest, EventCategory>();
    }
}