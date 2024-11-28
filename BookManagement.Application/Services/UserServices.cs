﻿using BookManagament.Models.InputModel;
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

        //List<User> listUsers = await _userRepository.GetAllUsers();
        //List<UsersViewModel> listFinal = ToUserDto(listUsers);

        //return listFinal;
    }

    public async Task<UsersViewModel> GetById(int id)
    {
        User user = await _userRepository.GetById(id);

        if (user == null)
        {
            return null; // Retorna null se o usuário não for encontrado
        }

        // Converte o objeto User para UsersViewModel
        UsersViewModel viewModel = ToUserDto(user);
        return viewModel;
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
