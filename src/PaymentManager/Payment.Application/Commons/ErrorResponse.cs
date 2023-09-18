using System.Net;

namespace Payment.Application.Commons;

public class ErrorResponse : Response
{
    public string Error { get; }
    public ErrorResponse(HttpStatusCode httpStatus, string error) : base(httpStatus)
        => Error = error;

    public static ErrorResponse Unauthorized(string error)
        => new(HttpStatusCode.Unauthorized, error);
}


