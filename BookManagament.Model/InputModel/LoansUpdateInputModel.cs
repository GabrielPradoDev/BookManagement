namespace BookManagament.Models.InputModel;

public class LoansUpdateInputModel
{
    //public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public bool Returned { get; set; }
}
