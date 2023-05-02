namespace AppBanca.Models.Domain;

public class ProductSupplier
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public int ReceiveQty { get; set; } = 0;
    public DateTime ReceiveDate { get; set; }
    public Product Product { get; set; }
    public Supplier Supplier { get; set; }
}
