using MediatR;
using Payment.Application.Commons;

namespace Payment.Application.Handlers.GetPaymentById;

public sealed record GetPaymentByIdRequest(Guid PaymentId) : IRequest<Response>;


