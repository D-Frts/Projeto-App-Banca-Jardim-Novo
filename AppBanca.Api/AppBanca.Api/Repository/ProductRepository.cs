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

    public override async Task<Product> Update(Product obj)
    {
        var prodUpdated = await _context.Products.FindAsync(obj.Id);
        if (prodUpdated != null)
        {
            prodUpdated.Id = obj.Id;
            prodUpdated.Name = obj.Name;
            prodUpdated.Description = obj.Description;
            prodUpdated.Price = obj.Price;
            prodUpdated.Quantity = obj.Quantity;
            prodUpdated.Invoice = obj.Invoice;
            prodUpdated.Code = obj.Code;
            prodUpdated.CategoryId = obj.CategoryId;
            prodUpdated.UpdatedAt = DateTime.Now.ToLocalTime();
            prodUpdated.ImageUrl = obj.ImageUrl;

            await _context.SaveChangesAsync();
        }
        return prodUpdated;
    }
}
