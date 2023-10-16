using MediatR;
using Payment.Application.Commons;
using Payment.Domain.Entities;
using Payment.Domain.Interfaces.Repositories;

namespace Payment.Application.Handlers.PostPayments;

public class PostPaymentHandler : IRequestHandler<PostPaymentRequest, Response>
{
    private readonly IDataBaseRespository _dataBaseRepository;

    public PostPaymentHandler(
        IDataBaseRespository dataBaseRepository)
    {
        _dataBaseRepository = dataBaseRepository;
    }

    public async Task<Response> Handle(PostPaymentRequest request, CancellationToken cancellationToken)
    {
        var payment = PaymentEntity.Factory(
            idempotencyKey: request.IdempotencyKey,
            payee: request.Payee,
            payer: request.Payer,
            amount: request.Amount,
            createdAt: DateTime.UtcNow);


        await _dataBaseRepository.UpsertAsync(payment, cancellationToken);

        return PostPaymentResponse.Created(payment.Id);
    }
}

