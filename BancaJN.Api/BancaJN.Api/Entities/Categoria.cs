using System.Text.Json.Serialization;

namespace BancaJN.Api.Entities;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }

    [JsonIgnore]
    public ICollection<Produto>? Produtos { get; set; }
}

