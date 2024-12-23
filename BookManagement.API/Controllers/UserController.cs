﻿using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;
using BookManagement.Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<UsersViewModel>>> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    // GET api/users/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(new { Message =ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UsersInputModel input)
    {
        if(input == null)
        {
            return BadRequest("Dados do usuario obrigatório");
        }
        var createdUser = await _userService.CreateUser(input);

        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id}, createdUser);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult>UpdateUser(int id,[FromBody] UsersUpdateInputModel input)
    {
        if (input == null)
        {
            return BadRequest("Dados Invalidos");
        }
        var updateUser = await _userService.UpdateUser(id,input);

        if (updateUser == null)
        {
            return NotFound($"Usuario com Id {id} não encontrado ");
        }

        return Ok(updateUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _userService.DeleteUser(id);

        if (!result)
        {
            return NotFound($"Usuario com Id {id} não foi encontrado");
        }

        return NoContent();
    }

    #region COMENTARIO PARA FAZER DEPOIS
    // POST api/users
    //[HttpPost]
    //public IActionResult Post(CreateUserInputModel model)
    //{
    //    return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    //}

    // GET api/users/id
    //[HttpGet("{id}")]
    //public IActionResult GetById(int id)
    //{

    //    return Ok();
    //}
    //  // PUT api/users/1234
    //[HttpPut("{id}")]
    //public IActionResult Put(int id, UpdateUserInputModel model)
    //{
    //    return NoContent();
    //}


    // DELETE api/users/1234
    //[HttpDelete("{id}")]
    //public IActionResult Delete(int id)
    //{
    //    return NoContent();
    //}
    #endregion
}
