namespace SloganSAP.API.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    // Many-to-many with Order
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
