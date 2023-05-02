using AppBanca.Models.Domain;
using AppBanca.Models.Dtos.Outputs;
using AutoMapper;

namespace AppBanca.Api.MappingProfiles;

public class OutputMappings : Profile
{
    public OutputMappings()
    {
        CreateMap<Product, ProductOutpuDto>()
            .ForMember(dest => dest.CategoryName, src => src.MapFrom(cn => cn.Category.Name)); 

        CreateMap<Category, CategoryOutputDto>();

        CreateMap<Supplier, SupplierOutputDto>();

    }
}
