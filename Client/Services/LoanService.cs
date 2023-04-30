using Client.Extensions;
using Flurl;
using Flurl.Http;
using IdentityModel.Client;
using LoanManager.Domain.Entities.Loan;

namespace Client.Services
{
    public class LoanService : ILoanService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private IHttpContextAccessor HttpContextAccessor { get; set; }

        public LoanService(IConfiguration configuration, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            this._tokenService = tokenService;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task CreateLoan(Loan loan)
        {
            var token = await _tokenService.GetToken();
            await _configuration["apiUrl"]
                .AppendPathSegment("/api/Loans")
                .WithOAuthBearerToken(token.AccessToken)
                .PostJsonAsync(loan);
        }

        public async Task<Loan> GetLoanById(int id)
        {
            var token = await _tokenService.GetToken();
            return await _configuration["apiUrl"].ToString()
                .AppendPathSegment($"/api/Loans/{id}")
                .WithOAuthBearerToken(token.AccessToken)
                .GetJsonAsync<Loan>();
        }

        public async Task<List<Loan>> GetUserLoans()
        {
            var userId = HttpContextAccessor.HttpContext.GetUserId();
            var token = await _tokenService.GetToken();
            return await _configuration["apiUrl"].ToString()
                .AppendPathSegment($"/api/Loans/user_loans/{userId}")
                .WithOAuthBearerToken(token.AccessToken)
                .GetJsonAsync<List<Loan>>();
        }
    }
}
