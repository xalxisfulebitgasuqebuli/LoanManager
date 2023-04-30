using LoanManager.Domain.Entities.Loan;
using LoanManager.Service.Abstraction;
using LoanManager.Service.Loans.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManager.Service.Loans.QueryHandlers
{
    public class GetLoanByIdHandler : IRequestHandler<GetLoanById, Loan>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByIdHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Loan> Handle(GetLoanById request, CancellationToken cancellationToken)
        {
            return await _loanRepository.GetLoanById(request.LoanId);
        }
    }
}
