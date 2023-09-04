using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Handlers.PostPayments;

namespace Payment.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("v{version:apiVersion}/payments")]
public sealed class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
        => _mediator = mediator;
  
    [HttpPost()]
    public async Task<IActionResult> Create(
        [FromBody] PostPaymentRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);

        return StatusCode((int)result.HttpStatusCode, result);
    }
}

