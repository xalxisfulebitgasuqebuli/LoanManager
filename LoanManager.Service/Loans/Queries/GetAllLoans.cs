using LoanManager.Domain.Entities.Loan;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManager.Service.Loans.Queries
{
    public class GetAllLoans : IRequest<ICollection<Loan>>
    {
        public string UserId { get; set; }
    }
}
