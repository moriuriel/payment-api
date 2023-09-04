using MediatR;
using Payment.Application.Commons;

namespace Payment.Application.Handlers.PostPayments;

public sealed record PostPaymentRequest(Guid Payee, Guid Payer, float Amount): IRequest<Response>;