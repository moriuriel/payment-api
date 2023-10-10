using MongoDB.Driver;
using Payment.Domain.Entities;
using Payment.Domain.Interfaces.Repositories;
using Payment.Infrastructure.Database.Contexts;

namespace Payment.Infrastructure.Database.Repositories;

internal sealed class MongoDbRepository : IDataBaseRespository
{
    public MongoDbRepository(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    private readonly IMongoDbContext _mongoDbContext;

    public async Task UpsertAsync(PaymentEntity payment, CancellationToken cancellationToken)
    {
        var filter = Builders<PaymentEntity>.Filter.Eq("Id", payment.Id);

        await _mongoDbContext
            .GetCollection<PaymentEntity>()
            .ReplaceOneAsync(filter, payment, options: new ReplaceOptions { IsUpsert = true}, cancellationToken);
    }

    public async Task<PaymentEntity> FindById(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<PaymentEntity>.Filter.Eq("Id", id);

        return await _mongoDbContext
            .GetCollection<PaymentEntity>()
            .Find(filter).FirstOrDefaultAsync(cancellationToken);
    }
}


