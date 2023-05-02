namespace AppBanca.Models.Domain;

public class Product
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
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Category Category { get; set; }    
    public ICollection<ProductSupplier> ProductsSuppliers { get; set; }

}
