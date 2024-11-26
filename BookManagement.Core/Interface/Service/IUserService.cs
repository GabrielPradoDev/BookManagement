using BookManagament.Models.ViewModel;
using BookManagement.Core.Entities;

namespace BookManagement.Core.Interface.Service;

public interface IUserService
{
    Task<List<UsersViewModel>> GetAllUsers();
    Task<UsersViewModel> GetById(int id);
}
