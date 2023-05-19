using AppBanca.Models.Domain;

namespace AppBanca.Web.Services.Intefaces;

public interface IBancaService<T> where T : class
{
    Task<T> GetItem(int id, string uri);
    Task<IEnumerable<T>> GetItems(string uri);
    Task AddItem(T obj, string uri);
    Task DeleteItem(string uri);
    Task UpdateItem(T obj, string uri);
}
