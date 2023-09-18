using System.Net;

namespace Payment.CrossCutting.Extensions;

public static class HttpStatusCodeExtension
{
    public static bool IsSuccessStatusCode(this HttpStatusCode statusCode)
    {
        var statusCodeNumber = (int)statusCode;
        return statusCodeNumber >= 200 && statusCodeNumber <= 299;
    }
}


