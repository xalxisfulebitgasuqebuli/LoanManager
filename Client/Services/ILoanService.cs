using LoanManager.Domain.Entities.Loan;

namespace Client.Services
{
    public interface ILoanService
    {
        Task<List<Loan>> GetUserLoans();
        Task<Loan> GetLoanById(int id);

        Task CreateLoan(Loan loan);
    }
}
