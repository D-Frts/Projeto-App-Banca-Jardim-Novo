using AppBanca.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace AppBanca.Api.Repository.Iterfaces;

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
        //return await dbContext.Set<T>().AsQueryable().ToListAsync();
        return await dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
    //TODO
    public virtual async Task<T> Update(T obj)
    {
        throw new Exception();
    }
}
