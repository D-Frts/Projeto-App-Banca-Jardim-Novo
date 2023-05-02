using AutoMapper;
using BancaJN.Api.Data.Repository.Contracts;
using BancaJN.Model.DataTransferObjects;

namespace BancaJN.Api.Data.Repository;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly BancaDbContext _bancaDbContext;
    private readonly IMapper _mapper;

    public ProdutoRepositorio(BancaDbContext bancaDbContext, IMapper mapper)
    {
        _bancaDbContext = bancaDbContext;
        _mapper = mapper;
    }

    public async Task<Produto> AdicionaItem(Produto produto)
    {
        var produtoExiste = await _bancaDbContext.Produtos.FindAsync(produto.Id);

         if(produtoExiste == null) // se for igual a null, a entidade não existe e pode ser adicionada
        {
            await _bancaDbContext.Produtos.AddAsync(produto);
            await _bancaDbContext.SaveChangesAsync();
            return produto;
        }

        return null;
    }

    public async Task<Produto> AtualizaItem(Produto produto)
    {
        var produtoAtualizado = await _bancaDbContext.Produtos.FindAsync(produto.Id);
        if (produtoAtualizado != null)
        {
            produtoAtualizado.Nome = produto.Nome;
            produtoAtualizado.Descricao = produto.Descricao;
            produtoAtualizado.Codigo = produto.Codigo;
            produtoAtualizado.NotaFiscal = produto.NotaFiscal;
            produtoAtualizado.Quantidade = produto.Quantidade;
            produtoAtualizado.Preco = produto.Preco;
            produtoAtualizado.CategoriaId = produto.CategoriaId;
            produtoAtualizado.ImagemUrl = produto.ImagemUrl;

            await _bancaDbContext.SaveChangesAsync();
            return produtoAtualizado;
        }
        return null;
        
    }

    public async Task<Produto> ExcluiItemPorId(int itemId)
    {
        var itemExcluir = await _bancaDbContext.Produtos.FindAsync(itemId);

        if (itemExcluir != null)
        {
            _bancaDbContext.Produtos.Remove(itemExcluir);
            await _bancaDbContext.SaveChangesAsync();
            return itemExcluir;
        }

        return null;
    }

    public async Task<Produto> ObtemItemPorId(int itemId)
    {

        //var item = await _bancaDbContext.Produtos.FindAsync(itemId);
        var item = await _bancaDbContext.Produtos
                                        //.Include(c => c.Categoria) //inclui também a categoria do produto que está relacionada a tabela
                                        .SingleOrDefaultAsync(p => p.Id == itemId); //retorna o produto cujo Id é igual ao passado

        return item;

    }

    public async Task<IEnumerable<Produto>> ObtemItens()
    {

        //var itens = await _bancaDbContext.Produtos.ToListAsync();
        var itens = await _bancaDbContext.Produtos
                                         //.Include(c => c.Categoria)
                                         .ToListAsync();

        return itens;


    }
}

