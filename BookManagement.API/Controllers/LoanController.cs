using BookManagament.Models.ViewModel;
using BookManagement.Application.Services;
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
}
