using AppBanca.Models.Domain;

namespace AppBanca.Models.Dtos.Inputs;

public class ProductInputDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0.0m;
    public int Quantity { get; set; } = 0;
    public string ImageUrl { get; set; } = string.Empty;
    public string? Code { get; set; } = string.Empty;
    public string Invoice { get; set; } = string.Empty;

}
