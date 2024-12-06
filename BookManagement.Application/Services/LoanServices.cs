using BookManagament.Models.InputModel;
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

    public async Task<LoansViewModel> Create(LoanInputModel input)
    {
        if (input.ExpectedReturnDate <= DateTime.Now)
        {
           throw new ArgumentException("A data de devolução prevista deve ser maior que a data atual.");
        }

        var loan = new Loan
        {
            UserId = input.UserId,
            BookId = input.BookId,
            LoanDate = input.LoanDate,
            ExpectedReturnDate = input.ExpectedReturnDate,
            IsReturned = false
        };

        var createdLoan = await _loanrepository.Create(loan);

        return ToLoanDto(createdLoan);

    }


    public async Task<string> ReturnBook(int id)
    {
        // Busca o empréstimo no repositório
        var loan = await _loanrepository.GetLoanById(id);
        if (loan == null)
        {
            throw new KeyNotFoundException($"Empréstimo com ID {id} não encontrado.");
        }

        // Verifica se o livro já foi devolvido
        if (loan.IsReturned)
        {
            return "O livro já foi devolvido.";
        }

        // Atualiza a data de devolução e o status
        loan.ReturnDate = DateTime.Now;
        loan.IsReturned = true;

        // Salva as alterações no repositório
        await _loanrepository.UpdateLoan(loan);

        // Calcula o status da devolução
        var daysLate = (loan.ReturnDate.Value - loan.ExpectedReturnDate).Days;

        return daysLate > 0
            ? $"Livro devolvido com {daysLate} dias de atraso."
            : "Livro devolvido em dia.";
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
