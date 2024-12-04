using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;

namespace BookManagement.Infrastructure.Persistence.Repository;

public class BookRepository : IBookRepository
{
    private static List<Book> _books;

    // Inicializa a lista no construtor
    public BookRepository()
    {
        if (_books == null) // Inicializa apenas na primeira instância
        {
            _books = new List<Book>
            {
                new Book(1, "Livros Teste", "Gabriel","Sei la", 2024, 1,true),
                new Book(2, "Livros Teste de novo", "João","Igor", 2000, 10,false),
                new Book(3, "Livros Teste mais uma vez", "Paulo","a", 2021, 100,true),
            };
        }
    }

    public Task<List<Book>> GetAllUsers()
    {
        return Task.FromResult(_books);
    }

    public Task<Book> GetById(int id)
    {
        var books = _books.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(books);
    }

    public async Task<Book> CreateBook(Book book)
    {
        book.Id = _books.Any() ? _books.Max(u => u.Id) + 1 : 1; // Gera um ID único
        _books.Add(book); // Adiciona à lista
        return await Task.FromResult(book); // Retorna o usuário criado
    }

    public async Task<Book> UpdateBook(Book book)
    {

        var existingBook = _books.FirstOrDefault(u => u.Id == book.Id);
        if (existingBook == null)
        {
            throw new KeyNotFoundException($"Usuário com ID {book.Id} não encontrado.");
        }

        existingBook.Title = book.Title;
        existingBook.ISBN = book.ISBN;
        existingBook.Author = book.Author;
        existingBook.Year = book.Year;
        existingBook.QTD = book.QTD;
        existingBook.Available = book.Available;

        return await Task.FromResult(existingBook);
    }

    public async Task DeleteBook(int id)
    {
        var user = _books.FirstOrDefault(u => u.Id == id);

        if (user != null)
        {
            _books.Remove(user);
        }

        await Task.CompletedTask;
    }
}
