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
    public class DeleteLoanHandler : IRequestHandler<DeleteLoan>
    {
        private readonly ILoanRepository _loanRepository;

        public DeleteLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task Handle(DeleteLoan request, CancellationToken cancellationToken)
        {
            await _loanRepository.DeleteLoan(request.LoanId);
        }
    }
}
