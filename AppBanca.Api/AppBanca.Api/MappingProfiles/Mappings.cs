using AppBanca.Models.Domain;
using AppBanca.Models.Dtos;
using AutoMapper;

namespace AppBanca.Api.MappingProfiles;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
            //.ForMember(dest => dest.CategoryName, src => src.MapFrom(cn => cn.Category.Name)).ReverseMap(); 

        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<Supplier, SupplierDto>().ReverseMap();

    }
}
