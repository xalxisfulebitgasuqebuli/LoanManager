using LoanManager.Domain.Enums;

namespace LoanManager.Domain.Entities.Loan
{
    public class Loan
    {
        public int Id { get; set; }
        public LoanType LoanType { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public int LoanDurationMonths { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public string UserId { get; set; }
    }
}
