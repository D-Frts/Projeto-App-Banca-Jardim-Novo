namespace AppBanca.Models.Dtos.Inputs;

public class ProductSupplierInputDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public int ReceiveQty { get; set; } = 0;
    public DateTime ReceiveDate { get; set; }
}
