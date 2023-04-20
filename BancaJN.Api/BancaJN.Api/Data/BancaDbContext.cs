using BancaJN.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancaJN.Api.Data;

public class BancaDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    public BancaDbContext(DbContextOptions<BancaDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>()
            .HasOne(c => c.Categoria)
            .WithMany(p => p.Produtos)
            .HasForeignKey(fk => fk.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Produto>()
            .HasKey(pk => pk.Id);
        modelBuilder.Entity<Produto>()
            .Property(p => p.Codigo)
            .HasColumnType("VARCHAR(50)")
            .HasPrecision(50);
        modelBuilder.Entity<Produto>()
            .HasIndex(i => i.Codigo).IsUnique();
        modelBuilder.Entity<Produto>()
            .Property(p => p.Nome)
            .HasColumnType("VARCHAR(50)")
            .HasPrecision(50)
            .HasDefaultValue("NÃO IDENTIFICADO");
        modelBuilder.Entity<Produto>()
            .HasIndex(i => i.Nome).IsUnique();
        modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasColumnType("DECIMAL(10,2)")
            .HasPrecision(2, 10)
            .HasDefaultValue(0M);
        modelBuilder.Entity<Produto>()
            .Property(p => p.Descricao)
            .HasColumnType("VARCHAR(100)")
            .HasPrecision(100);
        modelBuilder.Entity<Produto>()
            .Property(p => p.ImagemUrl)
            .HasColumnType("VARCHAR(100)")
            .HasPrecision(100);
        modelBuilder.Entity<Produto>()
            .Property(p => p.Quantidade)
            .HasDefaultValue(0);

    }
}

