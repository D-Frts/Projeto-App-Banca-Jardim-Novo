using BancaJN.Model.DataTransferObjects;

namespace BancaJN.Api.Data.Repository.Contracts;

public interface IProdutoRepositorio
{
    Task<Produto> ObtemItemPorId(int itemId);
    Task<IEnumerable<Produto>> ObtemItens();
    Task<Produto> AdicionaItem(Produto produto);
    Task<Produto> AtualizaItem(Produto produto);
    Task<Produto> ExcluiItemPorId(int itemId);
}
