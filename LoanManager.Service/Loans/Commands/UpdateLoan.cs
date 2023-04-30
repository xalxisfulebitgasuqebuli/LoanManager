using LoanManager.Domain.Entities.Loan;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManager.Service.Loans.Commands
{
    public class UpdateLoan : IRequest<Loan>
    {
        public int LoanId { get; set; }
        public string LoanType { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int LoanDurationMonths { get; set; }
    }
}
