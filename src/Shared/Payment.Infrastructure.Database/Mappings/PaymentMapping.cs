using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Payment.Domain.Entities;
using Payment.Domain.Enums;

namespace Payment.Infrastructure.Database.Mappings;

internal static class PaymentMapping
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<PaymentEntity>(map =>
        {
            map.MapMember(_ => _.Payee)
            .SetIsRequired(true);

            map.MapMember(_ => _.Payer)
            .SetIsRequired(true);

            map.MapMember(_ => _.Amount)
            .SetIsRequired(true);

            map.MapMember(_ => _.IdempotecyKey)
            .SetIsRequired(true);

            map.MapMember(_ => _.Status)
            .SetIsRequired(true)
            .SetSerializer(
                serializer: new EnumSerializer<PaymentStatus>(BsonType.String));

            map.MapMember(_ => _.CreatedAt)
            .SetIsRequired(true);

            map.MapMember(_ => _.UpdatedAt)
            .SetIsRequired(true);

            map.MapCreator(_ => PaymentEntity.Factory(
                _.Payee,
                _.Payer,
                _.Amount,
                _.IdempotecyKey,
                _.CreatedAt,
                _.UpdatedAt,
                _.Id,
                _.Status
                ));
        });
    }
}


