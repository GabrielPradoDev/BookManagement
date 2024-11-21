namespace BookManagement.Core.Entities;

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public bool Returned { get; set; }

}
