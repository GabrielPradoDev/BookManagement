using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;
using BookManagement.Application.Services;
using BookManagement.Core.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{

    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<BookViewModel>>> GetAll()
    {
        var books = await _bookService.GetAllUsers();
        return Ok(books);
    }

    // GET api/books/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var book = await _bookService.GetById(id);
            return Ok(book);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BooksInputModel input)
    {
        if (input == null)
        {
            return BadRequest("Dados do usuario obrigatório");
        }
        var createdBook = await _bookService.CreateBook(input);

        return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
    }
}
