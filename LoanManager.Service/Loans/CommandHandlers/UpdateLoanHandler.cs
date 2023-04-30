using LoanManager.Domain.Entities.Loan;
using LoanManager.Service.Abstraction;
using LoanManager.Service.Loans.Commands;
using MediatR;

namespace LoanManager.Service.Loans.CommandHandlers
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoan, Loan>
    {
        private readonly ILoanRepository _loanRepository;

        public UpdateLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<Loan> Handle(UpdateLoan request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.UpdateLoan(
                new LoanUpdate 
                { 
                    Amount= request.Amount,
                    Currency= request.Currency,
                    LoanDurationMonths= request.LoanDurationMonths,
                    LoanType = request.LoanType
                }, request.LoanId);

            return loan;    
        }
    }
}
