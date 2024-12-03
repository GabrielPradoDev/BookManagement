using BookManagament.Models.ViewModel;
using BookManagement.Core.Entities;

namespace BookManagement.Core.Interface.Repository;

public interface IBookRepository
{
    Task<List<Book>> GetAllUsers();
    Task<Book> GetById(int id);
    Task<Book> CreateBook(Book newBook);
}
