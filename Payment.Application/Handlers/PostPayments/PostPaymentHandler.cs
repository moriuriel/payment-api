using MediatR;
using Payment.Application.Commons;
using Payment.Domain.Entities;
using Payment.Infrastructure.ExternalServices.PaymentAuthorizer;

namespace Payment.Application.Handlers.PostPayments;

public class PostPaymentHandler : IRequestHandler<PostPaymentRequest, Response>
{
    private readonly IPaymentAuthorizerService _paymentAuthorizerService;

    public PostPaymentHandler(IPaymentAuthorizerService paymentAuthorizerService)
    {
        _paymentAuthorizerService = paymentAuthorizerService;
    }

    public async Task<Response> Handle(PostPaymentRequest request, CancellationToken cancellationToken)
    {
        var payment = PaymentEntity.Factory(
            idempotencyKey: request.IdempotencyKey,
            payee: request.Payee,
            payer: request.Payer,
            amount: request.Amount,
            createdAt: DateTime.UtcNow);

        var paymentAuthorizer = await _paymentAuthorizerService.AuthorizePaymentAsync(cancellationToken);
        if (paymentAuthorizer is not null && !paymentAuthorizer.IsPaymentAuthorized())
        {
            payment.Unauthorize();
            return ErrorResponse.Unauthorized("Unauthorized payment");
        }

        payment.Authorize();
        return PostPaymentResponse.Created(Guid.NewGuid());
    }
}

