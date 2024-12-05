using BookManagement.Core.Entities;

namespace BookManagement.Core.Interface.Repository;

public interface ILoanRepository
{
    //Task<Loan> CreateLoan(Loan loan); // Cadastrar empréstimo
    Task<List<Loan>> GetAll(); // Listar todos os empréstimos
    Task<Loan> GetLoanById(int id); // Consultar empréstimo por ID
    //Task UpdateLoan(Loan loan); // Atualizar informações do empréstimo
}
