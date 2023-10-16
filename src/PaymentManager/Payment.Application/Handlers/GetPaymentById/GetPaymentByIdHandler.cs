using MediatR;
using Payment.Application.Commons;
using Payment.Domain.Interfaces.Repositories;

namespace Payment.Application.Handlers.GetPaymentById;
public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdRequest, Response>
{
    public GetPaymentByIdHandler(IDataBaseRespository dataBaseRespository)
    {
        _dataBaseRespository = dataBaseRespository;
    }

    private readonly IDataBaseRespository _dataBaseRespository;

    public async Task<Response> Handle(GetPaymentByIdRequest request, CancellationToken cancellationToken)
    {
        var payment = await _dataBaseRespository.FindById(request.PaymentId.ToString(), cancellationToken);

        if(payment is null)
        {
            return GetPaymentByIdResponse.NotContent();
        }

        return GetPaymentByIdResponse.Ok(payment);
    }
}


