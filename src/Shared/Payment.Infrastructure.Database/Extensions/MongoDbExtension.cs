using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Payment.Domain.Interfaces.Repositories;
using Payment.Infrastructure.Database.Contexts;
using Payment.Infrastructure.Database.Mappings;
using Payment.Infrastructure.Database.Repositories;
using Payment.Infrastructure.Database.Settings;

namespace Payment.Infrastructure.Database.Extensions;

public static class MongoDbExtension
{
    public static IServiceCollection AddCustomMongoDbContext(
        this IServiceCollection services,
        MongoDbSettings settings)
    { 
        services.AddSingleton<IMongoClient>(new MongoClient(connectionString: settings.ConnectionString));
        services.AddScoped<IMongoDbContext, MongoDbContext>();
        services.AddScoped<IDataBaseRespository, MongoDbRepository>();

        ConfigureMapping.Configure();
        return services;
    }
}


