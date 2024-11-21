namespace App.Models;

public class OrderItem
{
    public int ItemNumber { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    public decimal ItemAgreedPrice { get; set; }
    public string ItemComment { get; set; }
}
