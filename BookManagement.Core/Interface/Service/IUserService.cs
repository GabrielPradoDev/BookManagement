using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;

namespace BookManagement.Core.Interface.Service;

public interface IUserService
{
    Task<List<UsersViewModel>> GetAllUsers();
    Task<UsersViewModel> GetById(int id);
    Task<UsersViewModel> CreateUser(UsersInputModel input);
    Task<UsersViewModel> UpdateUser(int id,UsersUpdateInputModel input);
    Task<bool> DeleteUser(int id);
}
