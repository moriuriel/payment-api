using System.Text.Json.Serialization;

namespace Payment.Infrastructure.ExternalServices.PaymentAuthorizer;

public class PaymentAuthorizerModel
{
    private readonly string AuthorizedValue = "Authorized";

    [JsonPropertyName("message")]
    private string Authorized { get; set; }

    [JsonConstructor]
    public PaymentAuthorizerModel(string value)
    {
        Authorized = value;
    }

    public bool IsPaymentAuthorized() => Authorized.Equals(AuthorizedValue);
}


