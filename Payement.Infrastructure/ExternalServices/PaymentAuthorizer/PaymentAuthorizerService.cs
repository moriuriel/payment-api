using System.Text.Json;
using Payment.Infrastructure.ExternalServices.Commons;

namespace Payment.Infrastructure.ExternalServices.PaymentAuthorizer;

internal class PaymentAuthorizerService : IPaymentAuthorizerService
{
    private readonly HttpClient _httpClient;

    public PaymentAuthorizerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaymentAuthorizerModel?> AuthorizePaymentAsync(CancellationToken cancellationToken)
    {
        var httpResponse = await _httpClient.GetAsync(requestUri: string.Empty, cancellationToken);
        var responseContent = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        if (!httpResponse.IsSuccessStatusCode || string.IsNullOrEmpty(responseContent))
            throw new HttpRequestException(
                string.Format(Message.Error.HTTP_REQUEST, nameof(PaymentAuthorizerService), responseContent));

        try
        {
            return JsonSerializer.Deserialize<PaymentAuthorizerModel>(responseContent);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}


