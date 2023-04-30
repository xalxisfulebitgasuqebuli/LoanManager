using LoanManager.Domain.Entities.Loan;
using LoanManager.Repository.DataBase;
using LoanManager.Service.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManager.Repository.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext _ctx;

        public LoanRepository(LoanDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Loan> CreateLoan(Loan loan)
        {
            _ctx.Loans.Add(loan);
            await _ctx.SaveChangesAsync();
            return loan;
        }

        public async Task DeleteLoan(int id)
        {
            var loan = await _ctx.Loans.FirstOrDefaultAsync(l => l.Id == id);
            if (loan == null)
                return;

            _ctx.Loans.Remove(loan);

            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Loan>> GetAllLoans(string userId)
        {
            return await _ctx.Loans.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Loan> GetLoanById(int id)
        {
            return await _ctx.Loans.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Loan> UpdateLoan(LoanUpdate loan, int id)
        {
            var currentLoan = await _ctx.Loans.FirstOrDefaultAsync(l => l.Id == id);

            currentLoan.Currency = loan.Currency;
            currentLoan.Amount = loan.Amount;
            currentLoan.LoanDurationMonths = loan.LoanDurationMonths;
            currentLoan.LoanType = loan.LoanType;

            await _ctx.SaveChangesAsync();
            return currentLoan;
        }
    }
}
