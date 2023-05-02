using BancaJN.Model.DataTransferObjects;

namespace BancaJN.Api.Mapping;

public static class MappingDtos
{

    public static ProdutoDTO ConverteProdutoDTO(this Produto produto)
    {

        return new ProdutoDTO
        {
            Id = produto.Id,
            Codigo = produto.Codigo,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade,
            ImagemUrl = produto.ImagemUrl,
            CategoriaId = produto.Categoria.Id,
            CategoriaNome = produto.Categoria.Nome
            

        };
    }

    public static Produto ConverteDTOProduto(this ProdutoDTO produtoDto)
    {

        return new Produto
        {
            Id = produtoDto.Id,
            Codigo = produtoDto.Codigo,
            Nome = produtoDto.Nome,
            NotaFiscal = produtoDto.NotaFiscal,
            Descricao = produtoDto.Descricao,
            Preco = produtoDto.Preco,
            Quantidade = produtoDto.Quantidade,
            ImagemUrl = produtoDto.ImagemUrl,
        };
    }

        public static IEnumerable<ProdutoDTO> ConverteListaProdutosDTO(this IEnumerable<Produto> produtos)
    {
        return (from produto in produtos
                select new ProdutoDTO
                {
                    Id = produto.Id,
                    Codigo = produto.Codigo,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    ImagemUrl = produto.ImagemUrl,
                    CategoriaId = produto.Categoria.Id,
                    CategoriaNome = produto.Categoria.Nome

                }).ToList();
    }

    public static CategoriaDTO ConverteCategoriaDTO(this Categoria categoria)
    {
        return new CategoriaDTO
        {
            Id = categoria.Id,
            Nome = categoria.Nome
        };
    }

    public static IEnumerable<CategoriaDTO> ConverteListaCategoriasDTO(this IEnumerable<Categoria> categorias)
    {
        return (from categoria in categorias
                select new CategoriaDTO
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome

                }).ToList();
    }
}
