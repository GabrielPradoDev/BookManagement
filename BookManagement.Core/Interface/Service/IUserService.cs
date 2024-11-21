using BookManagament.Models.ViewModel;

namespace BookManagement.Core.Interface.Service;

public interface IUserService
{
    Task<List<UsersViewModel>> GetAllUsers();
}
