using BookManagement.Core.Entities;

namespace BookManagement.Core.Interface.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetById(int id);
}
