using BancaJN.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancaJN.Api.Data;

public class BancaDbContext:DbContext   
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    public BancaDbContext(DbContextOptions<BancaDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>()
            .HasOne(c => c.Categoria)
            .WithMany(p => p.Produtos)
            .HasForeignKey(fk => fk.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}

