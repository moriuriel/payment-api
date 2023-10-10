using MongoDB.Driver;
using Payment.Domain.Entities;

namespace Payment.Infrastructure.Database.Contexts;

public interface IMongoDbContext
{
    IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity: AggregateRoot;
}


