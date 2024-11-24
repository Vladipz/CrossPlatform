namespace App.Models;
public class Author
{
    public int AuthorId { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorInitials { get; set; }
    public string AuthorLastName { get; set; }
    public DateTime AuthorDateOfBirth { get; set; }
    public int AuthorGenderMFU { get; set; }
    public string AuthorContactDetails { get; set; }
    public string AuthorOtherDetails { get; set; }
}
