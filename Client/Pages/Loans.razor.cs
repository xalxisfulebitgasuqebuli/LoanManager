using Client.Extensions;
using Client.Services;
using IdentityModel.Client;
using LoanManager.Domain.Entities.Loan;
using Microsoft.AspNetCore.Components;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Pages
{
    public partial class Loans
    {
        private List<Loan> loans = new();
        [Inject] private ILoanService LoanService { get; set; }



        protected override async Task OnInitializedAsync()
        {
            loans = await LoanService.GetUserLoans();
        }
    }
}
