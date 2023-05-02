using AppBanca.Models.Domain;
using AppBanca.Models.Dtos.Inputs;
using AutoMapper;

namespace AppBanca.Api.MappingProfiles;

public class InputMappings : Profile
{
    public InputMappings()
    {

        CreateMap<ProductInputDto, Product>();

        CreateMap<CategoryInputDto, Category>();

        CreateMap<SupplierInputDto, Supplier>();

        
    }
}
