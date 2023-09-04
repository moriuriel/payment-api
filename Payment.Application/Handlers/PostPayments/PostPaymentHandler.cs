using MediatR;
using Payment.Application.Commons;
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
        var paymentAuthorizerModel = await _paymentAuthorizerService.AuthorizePaymentAsync(cancellationToken);
        if (paymentAuthorizerModel is not null && !paymentAuthorizerModel.IsPaymentAuthorized())
            return ErrorResponse.Unauthorized("Unauthorized payment");

        return PostPaymentResponse.Created(Guid.NewGuid());
    }
}

