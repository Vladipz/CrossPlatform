namespace App.Models;

public class Contact
{
    public int ContactId { get; set; }
    public int ContactTypeCode { get; set; }
    public virtual RefContactType RefContactType { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactWorkPhoneNumber { get; set; }
    public string ContactCellPhoneNumber { get; set; }
    public string ContactOtherDetails { get; set; }
}
