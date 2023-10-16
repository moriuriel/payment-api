using Payment.Domain.Enums;

namespace Payment.Domain.Entities;

public class PaymentEntity : AggregateRoot
{
    public Guid IdempotecyKey { get; set; }
    public Guid Payee { get; set; }
    public Guid Payer { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public PaymentStatus Status { get; private set; }

    private PaymentEntity(
        Guid? id,
        Guid payee,
        Guid payer,
        decimal amount,
        Guid idempotencyKey,
        PaymentStatus status,
        DateTime createdAt,
        DateTime? updatedAt = null) : base(id: id ?? Guid.NewGuid())
    {
        IdempotecyKey = idempotencyKey;
        Payee = payee;
        Payer = payer;
        Amount = amount;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Status = status;
    }

    public static PaymentEntity Factory(
        Guid payee,
        Guid payer,
        decimal amount,
        Guid idempotencyKey,
        DateTime createdAt,
        DateTime? updatedAt = null,
        Guid? id = null,
        PaymentStatus status = PaymentStatus.Pending)
    {
        return new PaymentEntity(
            id,
            payee,
            payer,
            amount,
            idempotencyKey,
            status,
            createdAt,
            updatedAt
            );
    }

    public void Authorize()
    {
        Status = PaymentStatus.Authorized;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Unauthorize()
    {
        Status = PaymentStatus.Unauthorized;
        UpdatedAt = DateTime.UtcNow;
    }
}


