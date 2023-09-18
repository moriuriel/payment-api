using System.Net;
using Payment.Application.Commons;

namespace Payment.Application.Handlers.PostPayments;
public sealed class PostPaymentResponse : Response
{
    public Guid PaymentId { get; }
    public PostPaymentResponse(HttpStatusCode httpStatusCode, Guid paymentId) : base(httpStatusCode)
        => PaymentId = paymentId;

    public static PostPaymentResponse Created(Guid paymentId)
        => new(HttpStatusCode.Created,paymentId);
}


