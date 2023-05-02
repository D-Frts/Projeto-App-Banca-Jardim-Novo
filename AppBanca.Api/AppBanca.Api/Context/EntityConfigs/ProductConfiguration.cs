using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppBanca.Api.Context.EntityConfigs;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> product)
    {
        product.HasIndex(i => i.Name).IsUnique();
        product.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
        product.Property(p => p.Code).HasMaxLength(100).IsRequired(true);
        product.Property(p => p.Description).HasMaxLength(250).IsRequired(false);
        product.Property(p => p.Price).HasPrecision(10, 2).HasDefaultValue(0.00m);
        product.Property(p => p.Quantity).HasDefaultValue(0);
        product.Property(p=>p.CreatedAt).HasDefaultValue(DateTime.Now);
        product.Property(p => p.UpdatedAt).HasDefaultValue(DateTime.Now);
    }
}
