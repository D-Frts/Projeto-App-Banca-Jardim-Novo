namespace BancaJN.Api.Data;

public class BancaDbContext : DbContext
{
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Fornecedor>? Fornecedores { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<ProdutoFornecedor>? ProdutosFornecedores { get; set; }

    public BancaDbContext(DbContextOptions<BancaDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Configurações Entidade Produto

        modelBuilder.Entity<Produto>()
            .HasKey(pk => pk.Id);

        modelBuilder.Entity<Produto>()
            .HasOne(c => c.Categoria)
            .WithMany(p => p.Produtos)
            .HasForeignKey(fk => fk.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Codigo)
            .HasPrecision(50);

        modelBuilder.Entity<Produto>()
            .HasIndex(i => i.Codigo).IsUnique();

        modelBuilder.Entity<Produto>()
            .Property(p => p.Nome)
            .HasPrecision(50)
            .HasDefaultValue("NÃO IDENTIFICADO");

        modelBuilder.Entity<Produto>()
           .Property(p => p.NotaFiscal)
           .HasPrecision(50);

        modelBuilder.Entity<Produto>()
            .HasIndex(i => i.Nome).IsUnique();

        modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasPrecision(precision: 10, scale: 2)
            .HasDefaultValue(0M);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Descricao)
            .HasPrecision(100);

        //modelBuilder.Entity<Produto>()
        //    .Property(p => p.ImagemUrl)
        //    .HasPrecision(100);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Quantidade)
            .HasDefaultValue(0);

        modelBuilder.Entity<Fornecedor>()
            .HasKey(pk => pk.Id);

        #endregion

        #region Configurações Entidade Fornecedor

        modelBuilder.Entity<Fornecedor>()
            .HasKey(pk => pk.Id);

        modelBuilder.Entity<Fornecedor>()
            .Property(p => p.Nome)
            .HasPrecision(100)
            .HasDefaultValue("NÃO IDENTIFICADO");

        modelBuilder.Entity<Fornecedor>()
            .Property(p => p.Cnpj)
            .HasColumnType("CHAR(14)")
            .HasPrecision(14);

        modelBuilder.Entity<Fornecedor>()
            .HasIndex(i => i.Cnpj).IsUnique();

        modelBuilder.Entity<Fornecedor>()
            .Property(p => p.Margem)
            .HasPrecision(precision: 4, scale: 3)
            .HasDefaultValue(0.0m);


        #endregion

        #region Configurações Entidade de junção ProdutoFornecedor

        modelBuilder.Entity<ProdutoFornecedor>()
            .HasKey(pk => pk.Id);

        modelBuilder.Entity<ProdutoFornecedor>()
            .Property(p => p.DataRecebimento)
            .HasColumnType("DATETIME");

        #endregion

        #region Configuração de relação n:m entidades Produto Fornecedor

        modelBuilder.Entity<ProdutoFornecedor>()
            .HasOne(pf => pf.Produto)
            .WithMany(p => p.ProdutosFornecedores)
            .HasForeignKey(fk => fk.ProdutoId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProdutoFornecedor>()
            .HasOne(pf => pf.Fornecedor)
            .WithMany(f => f.ProdutosFornecedores)
            .HasForeignKey(fk => fk.FornecedorId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}

