using LoanManager.Domain.Entities.Loan;
using MediatR;


namespace LoanManager.Service.Loans.Queries
{
    public class GetLoanById : IRequest<Loan>
    {
        public int LoanId { get; set; }
    }
}
