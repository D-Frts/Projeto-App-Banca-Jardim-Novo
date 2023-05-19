using System.ComponentModel.DataAnnotations;

namespace AppBanca.Models.Dtos;

public class CategoryDto
{
    
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
}
