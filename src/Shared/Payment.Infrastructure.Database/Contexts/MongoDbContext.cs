using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.Domain.Entities;
using Payment.Infrastructure.Database.Settings;

namespace Payment.Infrastructure.Database.Contexts;

internal sealed class MongoDbContext : IMongoDbContext
{
    private readonly string _collectionName;
    private readonly IMongoDatabase _mongoDatabase;

    public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings, IMongoClient client)
    {
        _collectionName = mongoDbSettings.Value.Collection;
        _mongoDatabase = client.GetDatabase(name: mongoDbSettings.Value.Database);
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : AggregateRoot
        => _mongoDatabase.GetCollection<TEntity>(name: _collectionName);

}


