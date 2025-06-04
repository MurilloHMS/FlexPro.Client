using System.Net;

namespace FlexPro.Client.Models;

public class ApiResponse<T> 
{
    public string Message { get; set; }
    public HttpStatusCode  StatusCode { get; set; }
    public T Data { get; set; }

    public ApiResponse(string message, HttpStatusCode statusCode, T data = default(T))
    {
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }
    
    
}