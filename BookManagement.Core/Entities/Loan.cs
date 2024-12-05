namespace BookManagement.Core.Entities;

public class Loan
{
    public Loan() { }

    public Loan(int id, int userId, User user, int bookId, Book book, DateTime loanDate, DateTime expectedReturnDate, DateTime? returnDate, bool isReturned)
    {
        Id = id;
        UserId = userId;
        User = user;
        BookId = bookId;
        Book = book;
        LoanDate = loanDate;
        ExpectedReturnDate = expectedReturnDate;
        ReturnDate = returnDate;
        IsReturned = isReturned;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } // Relacionamento com User
    public int BookId { get; set; }
    public Book Book { get; set; } // Relacionamento com Book
    public DateTime LoanDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }

}
