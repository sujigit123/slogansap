namespace SloganSAP.API.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }

    // Many-to-many with Product
    public ICollection<Product> Products { get; set; } = new List<Product>();

    // One-to-one with Payment
    public Payment? Payment { get; set; }
}
