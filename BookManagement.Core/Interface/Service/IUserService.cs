using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;
using BookManagement.Core.Entities;

namespace BookManagement.Core.Interface.Service;

public interface IUserService
{
    Task<List<UsersViewModel>> GetAllUsers();
    Task<UsersViewModel> GetById(int id);
    Task<UsersViewModel> CreateUser(UsersInputModel input);
    Task<UsersViewModel> UpdateUser(int id,UsersUpdateInputModel input);
}
