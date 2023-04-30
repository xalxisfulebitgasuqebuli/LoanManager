using LoanManager.Service.Loans.Commands;
using LoanManager.Service.Loans.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanManager.API.Controllers
{
    [Authorize]
    public class LoansController : BaseController
    {

        [HttpGet("{LoanId}")]
        public async Task<IResult> GetLoanById([FromRoute] GetLoanById getLoanById)
        {
            var loan = await Mediator.Send(getLoanById);

            return TypedResults.Ok(loan);
        }

        [HttpPost]
        public async Task<IResult> CreateLoan([FromBody] CreateLoan createLoan)
        {
            var submittedLoan = await Mediator.Send(createLoan);

            return Results.CreatedAtRoute("GetLoanById", new { id = submittedLoan.Id }, submittedLoan);
        }

        [HttpGet("user_loans/{UserId}")]
        public async Task<IResult> GeUserLoans([FromRoute] GetAllLoans getAllLoans)
        {
            var loans = await Mediator.Send(getAllLoans);

            return TypedResults.Ok(loans);
        }

        [HttpPut]
        public async Task<IResult> UpdateLoan([FromBody] UpdateLoan updateLoan)
        {
            var submittedLoan = await Mediator.Send(updateLoan);
            return TypedResults.Ok(submittedLoan);
        }

        [HttpDelete("{LoanId}")]
        public async Task<IResult> DeleteLoan([FromRoute] DeleteLoan deleteLoan)
        {
            ;
            await Mediator.Send(deleteLoan);
            return TypedResults.NoContent();
        }
    }
}
