using BookManagament.Models.ViewModel;
using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;
using BookManagement.Core.Interface.Service;

namespace BookManagement.Application.Services;

public class UserServices : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<List<UsersViewModel>> GetAllUsers()
    {
        List<User> listUsers = await _userRepository.GetAllUsers();
        List<UsersViewModel> listFinal = ToUserDto(listUsers);

        return listFinal;
    }

    public List<UsersViewModel> ToUserDto(List<User> users)
    {
        List<UsersViewModel> list = new List<UsersViewModel>();
        foreach (User user in users)
        {
            UsersViewModel viewModel = new UsersViewModel()
            {
               Name = user.Name,
               Email = user.Email,
               Phone = user.Phone
            };
            list.Add(viewModel);
        }
        return list;
    }
}
