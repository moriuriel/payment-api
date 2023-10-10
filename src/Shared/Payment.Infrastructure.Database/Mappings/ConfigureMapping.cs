using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Payment.Infrastructure.Database.Mappings;

internal static class ConfigureMapping
{
    public static void Configure()
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

        EntityMapping.Configure();
        PaymentMapping.Configure();
    }
}


