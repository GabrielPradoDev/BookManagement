using BookManagament.Models.ViewModel;
using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;
using BookManagement.Core.Interface.Service;

namespace BookManagement.Application.Services;

public class LoanServices : ILoanService
{
    private readonly ILoanRepository _loanrepository;
    public LoanServices(ILoanRepository loanrepository)
    {
        _loanrepository = loanrepository;
    }
    public async Task<List<LoansViewModel>> GetAll()
    {
        var loans = await _loanrepository.GetAll();
        if (loans == null || !loans.Any())
        {
            return new List<LoansViewModel>(); // Retorna uma lista vazia se nenhum empréstimo for encontrado
        }
        var loansViewModel = loans.Select(ToLoanDto).ToList();
        return loansViewModel;
    }
    public async Task<LoansViewModel> GetLoanById(int id)
    {
        var loan = await _loanrepository.GetLoanById(id);

        if (loan == null)
        {
            throw new KeyNotFoundException($"Empréstimo com Id {id} não encontrado.");
        }

        return ToLoanDto(loan);
    }


    // Método auxiliar para converter um único User em UsersViewModel
    public LoansViewModel ToLoanDto(Loan loan)
    {
        return new LoansViewModel
        {
            Id = loan.Id,
            UserName = loan.User?.Name ?? "Usuário não encontrado",
            BookTitle = loan.Book?.Title ?? "Livro não encontrado",
            LoanDate = loan.LoanDate,
            ExpectedReturnDate = loan.ExpectedReturnDate,
            ReturnDate = loan.ReturnDate,
            Status = CalculateStatus(loan)
        };
    }

    private string CalculateStatus(Loan loan)
    {
        if (loan.IsReturned)
        {
            return loan.ReturnDate <= loan.ExpectedReturnDate
                ? "Devolvido em dia"
                : $"Devolvido com {(loan.ReturnDate.Value - loan.ExpectedReturnDate).Days} dias de atraso";
        }

        return DateTime.Now > loan.ExpectedReturnDate
            ? $"Atrasado {(DateTime.Now - loan.ExpectedReturnDate).Days} dias"
            : "Em dia";
    }

}
