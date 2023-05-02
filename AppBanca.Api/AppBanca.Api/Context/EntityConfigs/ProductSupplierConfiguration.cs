using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppBanca.Api.Context.EntityConfigs;

public class ProductSupplierConfiguration : IEntityTypeConfiguration<ProductSupplier>
{
    public void Configure(EntityTypeBuilder<ProductSupplier> productSupplier)
    {
        productSupplier.HasKey(pk => pk.Id);
        productSupplier.HasOne(p => p.Product) //configuração n:m divididas em 2 relações 1:n
                       .WithMany(ps => ps.ProductsSuppliers)
                       .HasForeignKey(fk => fk.ProductId)
                       .OnDelete(DeleteBehavior.Restrict);
        productSupplier.HasOne(s => s.Supplier)
                       .WithMany(ps => ps.ProductsSuppliers)
                       .HasForeignKey(fk => fk.SupplierId)
                       .OnDelete(DeleteBehavior.Restrict);
        productSupplier.Property(p => p.ReceiveDate).HasDefaultValue(DateTime.Now);
    }
}
