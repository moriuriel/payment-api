using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Payment.Infrastructure.ExternalServices.PaymentAuthorizer;

public static class PaymentAuthorizerExtension
{
    public static IServiceCollection AddPaymentAuthorizerService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient<IPaymentAuthorizerService, PaymentAuthorizerService>(client =>
        {
            var url = configuration.GetSection("AuthorizerSettings").Value;

            client.BaseAddress = new Uri($"{url}/v3/8fafdd68-a090-496f-8c9a-3442cf30dae6");
        });

        return services;
    }
}


