using Payment.Domain.Entities;

namespace Payment.Domain.Interfaces.Repositories;

public interface IDataBaseRespository
{
    Task UpsertAsync(PaymentEntity payment, CancellationToken cancellationToken);
    Task<PaymentEntity> FindById(string id, CancellationToken cancellationToken);
}


