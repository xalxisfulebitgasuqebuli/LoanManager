using LoanManager.Domain.Entities.Loan;
using Microsoft.EntityFrameworkCore;

namespace LoanManager.Repository.DataBase
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions opt) : base(opt)
        {
            
        }

        public DbSet<Loan> Loans { get; set; }
    }
}
