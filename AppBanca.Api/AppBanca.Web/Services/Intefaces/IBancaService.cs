using AppBanca.Models.Domain;

namespace AppBanca.Web.Services.Intefaces;

public interface IBancaService<T> where T : class
{
    Task<T> GetItem(int id, string uri);
    Task<IEnumerable<T>> GetItems(string uri);
}
