using B3Project.Applications.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace B3Project.Server.Controllers
{
    [Route("api/B3/FixedIncome")]
    public class FixedIncomeInvestmentController : Controller
    {
        private readonly IMediator _mediator;

        public FixedIncomeInvestmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromQuery] FixedIncomeCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
