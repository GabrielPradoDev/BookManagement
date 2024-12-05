using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;
using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;
using BookManagement.Core.Interface.Service;

namespace BookManagement.Application.Services;

public class BookServices : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookServices(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookViewModel>> GetAllUsers()
    {
        var books = await _bookRepository.GetAllUsers();

        var booksViewModel = books.Select(ToUserDto).ToList();
        return booksViewModel;
    }

    public async Task<BookViewModel> GetById(int id)
    {
        Book book = await _bookRepository.GetById(id);

        if (book == null)
        {
            throw new KeyNotFoundException($"Livro com o Id {id} não encontrado ou não existe"); // Retorna null se o usuário não for encontrado
        }

        return ToUserDto(book);
    }
    public async Task<BookViewModel> CreateBook (BooksInputModel input)
    {
        var newBook = new Book
        {

            Title = input.Title,
            Author = input.Author,
            ISBN = input.ISBN,
            Year = input.Year,
            QTD = input.QTD,
            Available = input.Available
        };

        var createdBook = await _bookRepository.CreateBook(newBook);

        return ToUserDto(createdBook);
    }
    public async Task<BookViewModel> UpdateBook(int id, BooksUpdateInputModel input)
    {

        var book = await _bookRepository.GetById(id);
        if (book == null)
        {
            return null;
        }
        book.Title = input.Title;
        book.ISBN = input.ISBN;
        book.Year = input.Year;
        book.Author = input.Author;
        book.Available = input.Available;
        book.QTD = input.QTD;

        await _bookRepository.UpdateBook(book);

        return ToUserDto(book);
    }

    public async Task<bool> DeleteBook(int id)
    {
        var user = await _bookRepository.GetById(id);

        if (user == null)
        {
            return false;
        }

        await _bookRepository.DeleteBook(id);
        return true;
    }

    // Método auxiliar para converter um único User em UsersViewModel
    public BookViewModel ToUserDto(Book book)
    {
        return new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            Year  = book.Year,
            QTD = book.QTD,
            Available = book.Available
        };
    }

}
