using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    // GET api/books?search=chapeuzinho
    //[HttpGet]
    //public IActionResult Get(string search)
    //{
    //    return Ok();
    //}

    // GET api/books/123
    //[HttpGet("{id}")]
    //public IActionResult GetById(int id) 
    //{
    //    return Ok();
    //}

    // POST api/books
    //[HttpPost]
    // public IActionResult Post(CreateBookInputModel model)
    //{
    //    return CreatedAtAction(nameof (GetById), new {id = 1}, model);
    //}

    // PUT api/books/1234

    //[HttpPut("{id}")]

    //public IActionResult Put(int id, UpdateBookInputModel model)
    //{
    //    return NoContent();
    //}


    // DELETE api/books/1234
    //[HttpDelete("{id}")]
    //public IActionResult Delete(int id)
    //{
    //    return NoContent();
    //}

    
}
