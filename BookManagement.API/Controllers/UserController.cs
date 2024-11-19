using BookManagement.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok();
        }
        //  // PUT api/users/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserInputModel model)
        {
            return NoContent();
        }


        // DELETE api/users/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

    }
}
