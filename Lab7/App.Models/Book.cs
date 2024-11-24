namespace App.Models;

public class Book
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int BookCategoryCode { get; set; }
    public virtual BookCategory BookCategory { get; set; }
    public string ISBN { get; set; }
    public DateTime DateOfPublication { get; set; }
    public DateTime DateAcquired { get; set; }
    public string BookTitle { get; set; }
    public decimal BookRecommendedPrice { get; set; }
    public string BookComments { get; set; }
}
