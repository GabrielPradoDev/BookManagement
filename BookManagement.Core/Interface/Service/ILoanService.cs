using BookManagament.Models.InputModel;
using BookManagament.Models.ViewModel;

namespace BookManagement.Core.Interface.Service;

public interface ILoanService
{
    Task<List<LoansViewModel>> GetAll();

    Task<LoansViewModel> Create(LoanInputModel input); // Cadastrar empréstimo
   
    Task<LoansViewModel> GetLoanById(int id); // Consultar empréstimo por ID
    Task<string> ReturnBook(int id); // Devolver um livro
}
