using AutoMapper;
using BancaJN.Model.DataTransferObjects;

namespace BancaJN.Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto, ProdutoDTO>()
            .ForMember(dest => dest.CategoriaId, orig => orig.MapFrom(cid => cid.Categoria.Id))
            .ForMember(dest => dest.CategoriaNome, orig => orig.MapFrom(cn => cn.Categoria.Nome))
            .ReverseMap();
        
        CreateMap<IEnumerable<Produto>, IEnumerable<ProdutoDTO>>()
            .ReverseMap();

        CreateMap<Categoria, CategoriaDTO>()
            .ReverseMap();
    }
}
