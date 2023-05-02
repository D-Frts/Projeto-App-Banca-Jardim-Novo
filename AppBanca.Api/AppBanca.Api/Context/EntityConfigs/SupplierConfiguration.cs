using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppBanca.Api.Context.EntityConfigs;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> supplier)
    {
        supplier.HasIndex(i => i.Name).IsUnique();
        supplier.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
        supplier.Property(p => p.Cnpj).HasMaxLength(14).IsRequired(false);
        supplier.Property(p => p.Profit).HasPrecision(4, 3);
    }
}