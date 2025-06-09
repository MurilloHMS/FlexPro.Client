using System.Net;

namespace FlexPro.Client.Models;

public class ApiResponse<T>
{
    public ApiResponse(string message, HttpStatusCode statusCode, T data = default)
    {
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public T Data { get; set; }
}