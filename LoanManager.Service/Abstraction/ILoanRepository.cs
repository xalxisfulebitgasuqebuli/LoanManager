using LoanManager.Domain.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManager.Service.Abstraction
{
    public interface ILoanRepository 
    {
        Task<ICollection<Loan>> GetAllLoans(string userId);
        Task<Loan> GetLoanById(int id);
        Task<Loan> CreateLoan(Loan loan);
        Task<Loan> UpdateLoan(LoanUpdate loan, int id);
        Task DeleteLoan(int id);
    }
}
