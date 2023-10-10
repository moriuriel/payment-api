using MongoDB.Bson.Serialization;
using Payment.Domain.Entities;

namespace Payment.Infrastructure.Database.Mappings;

public static class EntityMapping
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Entity>(classMap =>
        {
            classMap.AutoMap();
        });
    }
}


