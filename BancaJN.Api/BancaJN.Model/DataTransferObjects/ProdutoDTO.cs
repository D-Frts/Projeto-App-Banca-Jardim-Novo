namespace BancaJN.Model.DataTransferObjects
{
    public class ProdutoDTO
    {

        public int Id { get; set; }
        public string? Codigo { get; set; } 
        public string? Nome { get; set; }
        public string? NotaFiscal { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string? ImagemUrl { get; set; }
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }

    }
}
