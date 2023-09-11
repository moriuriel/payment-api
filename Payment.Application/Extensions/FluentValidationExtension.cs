using Microsoft.Extensions.DependencyInjection;
using Payment.Application.Handlers.PostPayments;

namespace Payment.Application.Extensions;

public static class FluentValidationExtension
{
    public static IServiceCollection AddCustomFluentValidation(this IServiceCollection service)
    {
        service.AddScoped<PostPaymentRequestValidator>();
        return service;
    }
}

