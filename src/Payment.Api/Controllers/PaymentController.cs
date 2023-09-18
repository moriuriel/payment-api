using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Handlers.PostPayments;
using Payment.Application.Handlers.PostPayments.Dto;

namespace Payment.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("v{version:apiVersion}/payments")]
[ProducesResponseType(type: typeof(PostPaymentResponse), statusCode: (int)HttpStatusCode.Created)]
public sealed class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost()]
    public async Task<IActionResult> Create(
        [FromHeader][Required] Guid IdempotencyKey,
        [FromBody] PaymentDto request,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            request: new PostPaymentRequest(
                Payee: request.Payee,
                Payer: request.Payer,
                Amount: request.Amount,
                IdempotencyKey),
            cancellationToken);

        return StatusCode((int)result.HttpStatusCode, result);
    }
}

