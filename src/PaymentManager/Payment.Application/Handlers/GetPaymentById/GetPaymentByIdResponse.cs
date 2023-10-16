using System.Net;
using Payment.Application.Commons;
using Payment.Domain.Entities;

namespace Payment.Application.Handlers.GetPaymentById;
public class GetPaymentByIdResponse : Response
{
    public PaymentEntity? Payment { get; }

    public GetPaymentByIdResponse(HttpStatusCode httpStatusCode, PaymentEntity? payment) : base(httpStatusCode)
        => Payment = payment;

    public static GetPaymentByIdResponse NotContent()
        => new(HttpStatusCode.NoContent, null);

    public static GetPaymentByIdResponse Ok(PaymentEntity payment)
        => new(HttpStatusCode.OK, payment);
}


