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

    public Task<List<UsersViewModel>> GetAll()
    {
        return _userService.GetAllUsers();
    }

    // GET api/users/id
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

       return Ok();
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
