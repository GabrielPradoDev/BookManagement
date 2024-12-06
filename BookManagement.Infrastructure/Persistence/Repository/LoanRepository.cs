using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;

namespace BookManagement.Infrastructure.Persistence.Repository;

public class LoanRepository : ILoanRepository
{
    private static List<Loan> _loans;
    private static List<User> _users;
    private static List<Book> _books;

    public LoanRepository()
    {
        // Mock de usuários
        _users = new List<User>
        {
                new User(1, "Gustavo Caçador", "gustavo.cacador@email.com", "123-456-7890"),
                new User(2, "Ana Silva", "ana.silva@email.com", "987-654-3210"),
                new User(3, "Carlos Oliveira", "carlos.oliveira@email.com", "555-123-4567")
        };

        // Mock de livros
        _books = new List<Book>
        {
            new Book(1, "Livros Teste", "Gabriel","Sei la", 2024, 1,true),
            new Book(2, "Livros Teste de novo", "João","Igor", 2000, 10,false),
            new Book(3, "Livros Teste mais uma vez", "Paulo","a", 2021, 100,true),
        };

        // Mock de empréstimos
        _loans = new List<Loan>
        {
            new Loan
            {
                Id = 1,
                UserId = 1,
                BookId = 1,
                LoanDate = DateTime.Now.AddDays(-10),
                ExpectedReturnDate = DateTime.Now.AddDays(-3),
                ReturnDate = null,
                IsReturned = false
            },
            new Loan
            {
                Id = 2,
                UserId = 2,
                BookId = 2,
                LoanDate = DateTime.Now.AddDays(-20),
                ExpectedReturnDate = DateTime.Now.AddDays(-15),
                ReturnDate = DateTime.Now.AddDays(-12),
                IsReturned = true
            }
        };
    }

    public async Task<List<Loan>> GetAll()
    {
        // Retorna a lista de empréstimos mockados com as associações de usuário e livro
        return await Task.FromResult(_loans.Select(loan =>
        {
            loan.User = _users.FirstOrDefault(u => u.Id == loan.UserId);
            loan.Book = _books.FirstOrDefault(b => b.Id == loan.BookId);
            return loan;
        }).ToList());
    }

    public async Task<Loan> GetLoanById(int id)
    {
        var loan = _loans.FirstOrDefault(l => l.Id == id);
        if (loan != null)
        {
            loan.User = _users.FirstOrDefault(u => u.Id == loan.UserId);
            loan.Book = _books.FirstOrDefault(b => b.Id == loan.BookId);
        }
        return await Task.FromResult(loan);
    }

    public async Task<Loan> Create(Loan loan)
    {
        loan.Id = _loans.Any() ? _loans.Max(l => l.Id) + 1 : 1;

        _loans.Add(loan);

        return await Task.FromResult(loan);
    }
}

