namespace BookManagement.Core.Entities;

public class Book
{
    public Book(int id,string? title, string? author, string? iSBN, int? year, int? qTD, bool? available)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = iSBN;
        Year = year;
        QTD = qTD;
        Available = available;
    }

    public Book()
    {

    }

    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public int? Year { get; set; }
    public int? QTD { get; set; }
    public bool? Available { get; set; }
}
