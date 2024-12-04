namespace BookManagament.Models.InputModel;

public class BooksUpdateInputModel
{
    //public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public int? Year { get; set; }
    public int? QTD { get; set; }
    public bool? Available { get; set; }
}
