namespace BookManagement.Core.Entities;

public class Loan
{
    public Loan(int id, int bookId, int userId, DateTime loanDate, bool returned)
    {
        Id = id;
        BookId = bookId;
        UserId = userId;
        LoanDate = loanDate;
        Returned = returned;
    }

    public Loan() { }

    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public bool Returned { get; set; }

}
