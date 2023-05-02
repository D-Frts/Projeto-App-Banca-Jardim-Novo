namespace BancaJN.Api.Entities;

public class Produto
{
    public int Id { get; set; }
    public string? Codigo { get; set; } = string.Empty;
    public string? Nome { get; set; } = string.Empty;
    public string? NotaFiscal { get; set; } = string.Empty;
    public string? Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public string? ImagemUrl { get; set; } = string.Empty;
    //public DateTime Data { get; set; }
    public Categoria? Categoria { get; set; } 
    public int CategoriaId { get; set; }
    public ICollection<ProdutoFornecedor>? ProdutosFornecedores { get; set; } 
}

