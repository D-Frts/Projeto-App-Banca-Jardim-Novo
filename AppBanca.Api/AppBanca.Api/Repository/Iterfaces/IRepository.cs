using AppBanca.Models.Domain;
using System.Runtime.CompilerServices;

namespace AppBanca.Api.Repository.Iterfaces;

public interface IRepository<T> where T : class
{
    Task<T> Create(T obj);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Update(T obj);
    Task Delete(int id);
    Task SaveChanges();
}
