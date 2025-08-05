using System.Net;

namespace FlexPro.Client.Domain.Models;

public class ApiResponse<T>
{
    public ApiResponse(string message, HttpStatusCode statusCode, T? data = default)
    {
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public bool IsSuccess => (int)StatusCode >= 200 && (int)StatusCode < 300;
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public T? Data { get; set; }

    public static ApiResponse<T> Success(T data, string message = "Requisição bem-sucedida")
    {
        return new ApiResponse<T>(message, HttpStatusCode.OK, data);
    }

    public static ApiResponse<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ApiResponse<T>(message, statusCode);
    }
}