using LoanManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManager.Domain.Entities.Loan
{
    public class LoanUpdate
    {
        public LoanType LoanType { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public int LoanDurationMonths { get; set; }
    }
}