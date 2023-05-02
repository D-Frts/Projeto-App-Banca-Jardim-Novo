using AppBanca.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppBanca.Api.Context.EntityConfigs;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
        category.HasIndex(i => i.Name).IsUnique();

        category.HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(fk => fk.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
