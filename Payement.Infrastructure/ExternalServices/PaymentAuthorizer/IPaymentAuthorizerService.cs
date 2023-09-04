namespace Payment.Infrastructure.ExternalServices.PaymentAuthorizer;

public interface IPaymentAuthorizerService
{
    Task<PaymentAuthorizerModel?> AuthorizePaymentAsync(CancellationToken cancellationToken);
}

