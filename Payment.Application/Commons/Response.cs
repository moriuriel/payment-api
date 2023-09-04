using System.Net;
using System.Text.Json.Serialization;
using Payment.CrossCutting.Extensions;

namespace Payment.Application.Commons;

public class Response
{
    protected Response(HttpStatusCode httpStatusCode)
        => HttpStatusCode = httpStatusCode;

    [JsonIgnore]
    public HttpStatusCode HttpStatusCode { get; }

    public bool IsSuccessStatusCode() => HttpStatusCode.IsSuccessStatusCode();
}


