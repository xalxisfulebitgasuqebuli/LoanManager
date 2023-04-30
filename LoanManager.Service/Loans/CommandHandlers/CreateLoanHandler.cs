using LoanManager.Domain.Entities.Loan;
using LoanManager.Service.Abstraction;
using LoanManager.Service.Loans.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManager.Service.Loans.CommandHandlers
{
    public class CreateLoanHandler : IRequestHandler<CreateLoan, Loan>
    {
        private readonly ILoanRepository _loanRepository;

        public CreateLoanHandler(ILoanRepository loanRepopsitory)
        {
            _loanRepository = loanRepopsitory;
        }
        public async Task<Loan> Handle(CreateLoan request, CancellationToken cancellationToken)
        {
            var newLoan = new Loan
            {
                Amount = request.Amount,
                Currency = request.Currency,
                LoanDurationMonths = request.LoanDurationMonths,
                LoanType = request.LoanType,
                LoanStatus = "pending"
            };

            return await _loanRepository.CreateLoan(newLoan);
        }
    }
}
