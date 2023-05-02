namespace BancaJN.Api.Entities;

public class Fornecedor
{
    public int Id { get; set; }
    public string? Nome { get; set; } = string.Empty;
    public string? Cnpj { get; set; } = string.Empty;
    public decimal Margem { get; set; } = 0.0m;
    public ICollection<ProdutoFornecedor>? ProdutosFornecedores { get; set; }
}

