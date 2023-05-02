using AppBanca.Api.Context;
using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace AppBanca.Api.Repository.Iterfaces;

public interface IRepository<T> where T : class
{
    Task<T> Create(T obj);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task Update(T obj);
    Task Delete(int id);
    Task SaveChanges();
}

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly AppBancaDbContext dbContext;

    public Repository(AppBancaDbContext context)
    {
        dbContext = context;
    }

    public virtual async Task<T> Create(T obj)
    {
        var entity = await dbContext.Set<T>().AddAsync(obj);
        if (entity.State == EntityState.Added)
            return entity.Entity;
        return null;

    }

    public virtual async Task Delete(int id)
    {
        var entity = await GetById(id);

        if(entity != null) dbContext.Set<T>().Remove(entity);
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await dbContext.Set<T>().AsQueryable().ToListAsync();
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }

    public Task Update(T obj)
    {
        dbContext.Update<T>(obj);
        return Task.CompletedTask;
    }
}
