using FluentValidation;
using Payment.Application.Handlers.PostPayments.Dto;

namespace Payment.Application.Handlers.PostPayments;

internal sealed class PostPaymentRequestValidator : AbstractValidator<PaymentDto>
{
    public PostPaymentRequestValidator()
    {
        RuleFor(_ => _.Payer)
            .NotEmpty();
        RuleFor(_ => _.Payee)
            .NotEmpty();
        RuleFor(_ => _.Amount)
            .NotEmpty();
    }
}
