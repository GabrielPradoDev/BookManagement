using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;
using BookManagement.Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;
    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<LoansViewModel>>> GetAll()
    {
        var loans = await _loanService.GetAll();
        if (loans == null || !loans.Any())
        {
            return NotFound("Nenhum empréstimo encontrado.");
        }
        return Ok(loans);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoanById(int id)
    {
        try
        {
            var loan = await _loanService.GetLoanById(id);

            if (loan == null)
            {
                return NotFound($"Empréstimo com Id {id} não encontrado.");
            }

            return Ok(loan); // Retorna o empréstimo no formato LoansViewModel
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor.", Details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LoanInputModel input)
    {
        if (input == null)
        {
            return BadRequest("Dados do emprestimo são obrigatório");
        }


        try
        {
            var createdLoan = await _loanService.Create(input);
            return CreatedAtAction(nameof(GetLoanById), new { id = createdLoan.Id }, createdLoan);
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor", Details = ex.Message });
        }
    }

    [HttpPut("return/{id}")]
    public async Task<IActionResult> ReturnBook(int id)
    {
        try
        {
            var message = await _loanService.ReturnBook(id);
            return Ok(new { Message = message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor.", Details = ex.Message });
        }
    }
}

