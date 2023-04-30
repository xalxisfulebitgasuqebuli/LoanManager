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
    public class GetAllLoansHandler : IRequestHandler<GetAllLoans, ICollection<Loan>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ICollection<Loan>> Handle(GetAllLoans request, CancellationToken cancellationToken)
        {
            return await _loanRepository.GetAllLoans(request.UserId);
        }
    }
}
