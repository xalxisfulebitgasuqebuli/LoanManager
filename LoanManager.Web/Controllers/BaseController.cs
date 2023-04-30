using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoanManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public readonly ISender _mediator;
        protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetService(typeof(ISender)) as ISender;
    }
}
