using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;
using BookManagement.Core.Entities;

namespace BookManagement.Core.Interface.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetById(int id);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
}
