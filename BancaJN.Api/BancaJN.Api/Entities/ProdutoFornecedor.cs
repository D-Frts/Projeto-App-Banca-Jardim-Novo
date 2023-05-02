namespace BancaJN.Api.Entities;

public class ProdutoFornecedor
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int FornecedorId { get; set; }
    public int QuantidadeRecebida { get; set; }
    public DateTime DataRecebimento { get; set; }
    public Produto? Produto { get; set; }
    public Fornecedor? Fornecedor { get; set; }


}
