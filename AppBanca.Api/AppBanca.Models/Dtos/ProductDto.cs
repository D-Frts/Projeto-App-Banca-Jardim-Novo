using System.ComponentModel.DataAnnotations;

namespace AppBanca.Models.Dtos;

public class ProductDto
{
    [Key]
    public int Id { get; set; }
    [Required (ErrorMessage = "Campo obrigatório")]
    [DataType (DataType.Text)]
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo obrigatório")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; } = 0.0m;
    [Required(ErrorMessage = "Campo obrigatório")]
    public int Quantity { get; set; } = 0;
    public string? ImageUrl { get; set; } = string.Empty;
    public string? Code { get; set; } = string.Empty;
    public string? Invoice { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo obrigatório")]
    public int CategoryId { get; set; }

}
