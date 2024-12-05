namespace BookManagament.Models.InputModel;

public class LoanInputModel
{

    //public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
}
