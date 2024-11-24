namespace App.Models;


public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderValue { get; set; }
}
