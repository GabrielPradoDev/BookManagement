using BookManagament.Models.InputModel;
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
        var users = await _userRepository.GetAllUsers();

        var usersViewModel = users.Select(ToUserDto).ToList();
        return usersViewModel;
    }

    public async Task<UsersViewModel> GetById(int id)
    {
        User user = await _userRepository.GetById(id);

        if (user == null)
        {
           throw new KeyNotFoundException($"Usuario com o Id {id} não encontrado ou não existe"); // Retorna null se o usuário não for encontrado
        }

        return ToUserDto(user);
    }

    public async Task<UsersViewModel> CreateUser(UsersInputModel input)
    {
        var newUSer = new User
        {
            
            Name = input.Name,
            Email = input.Email,
            Phone = input.Phone
        };

        var createdUser = await _userRepository.CreateUser(newUSer);

        return ToUserDto(createdUser);
    }
    public async Task<UsersViewModel> UpdateUser(int id,UsersUpdateInputModel input)
    {
        var user = await _userRepository.GetById(id);
        if (user == null)
        {
            return null;
        }
        user.Name = input.Name;
        user.Email = input.Email;
        user.Phone = input.Phone;

        await _userRepository.UpdateUser(user);

        return ToUserDto(user);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _userRepository.GetById(id);

        if(user == null)
        {
            return false;
        }

        await _userRepository.DeleteUser(id);
        return true;
    }


    // Método auxiliar para converter um único User em UsersViewModel
    public UsersViewModel ToUserDto(User user)
    {
        return new UsersViewModel
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone
        };
    }

}
