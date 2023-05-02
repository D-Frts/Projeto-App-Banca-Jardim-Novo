using AppBanca.Api.Context.EntityConfigs;
using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppBanca.Api.Context;

public class AppBancaDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductSupplier> ProductsSuppliers { get; set; }

    public AppBancaDbContext(DbContextOptions<AppBancaDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
        modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration<ProductSupplier>(new ProductSupplierConfiguration());
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppBancaDbContext).Assembly);
    }
}
