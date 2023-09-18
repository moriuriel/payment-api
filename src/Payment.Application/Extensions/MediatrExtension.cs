using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Payment.Application.Extensions;

public static class MediatrExtension
{
    public static IServiceCollection AddCustomMediatr(this IServiceCollection services)
    {
        services.AddMediatR(_ => _.RegisterServicesFromAssemblies(
            assemblies: Assembly.GetExecutingAssembly()));

        return services;
    }
}
