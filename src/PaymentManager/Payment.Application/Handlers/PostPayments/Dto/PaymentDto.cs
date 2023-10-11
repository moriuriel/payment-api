namespace Payment.Application.Handlers.PostPayments.Dto;

public sealed record PaymentDto(Guid Payee,Guid Payer,decimal Amount);

