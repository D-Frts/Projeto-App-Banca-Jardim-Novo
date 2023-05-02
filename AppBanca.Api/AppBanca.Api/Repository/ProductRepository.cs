using AppBanca.Api.Context;
using AppBanca.Api.Repository.Iterfaces;
using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppBanca.Api.Repository;

public class ProductRepository : Repository<Product>
{
    private readonly AppBancaDbContext _context;

    public ProductRepository(AppBancaDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }
}
