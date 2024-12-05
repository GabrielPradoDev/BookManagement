namespace BookManagament.Models.ViewModel;

public class LoansViewModel
{

    public int Id { get; set; }
    public string UserName { get; set; }
    public string BookTitle { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; }
}
