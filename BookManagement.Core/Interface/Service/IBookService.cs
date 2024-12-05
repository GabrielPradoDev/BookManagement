using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;

namespace BookManagement.Core.Interface.Service;

public interface IBookService
{
    Task<List<BookViewModel>> GetAllUsers();
    Task<BookViewModel> GetById(int id);
    Task<BookViewModel> CreateBook(BooksInputModel input);
    Task<BookViewModel> UpdateBook(int id, BooksUpdateInputModel input);
    Task<bool> DeleteBook(int id);
}
