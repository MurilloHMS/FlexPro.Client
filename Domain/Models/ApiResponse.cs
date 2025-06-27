using System.Net;

namespace FlexPro.Client.Models;

public class ApiResponse<T>
{
    public bool IsSuccess => (int)StatusCode >= 200 && (int)StatusCode < 300;
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public T? Data { get; set; }
    
    public ApiResponse(string message, HttpStatusCode statusCode, T? data = default)
    {
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }
    
    public static ApiResponse<T> Success(T data, string message = "Requisição bem-sucedida") =>
        new( message,HttpStatusCode.OK, data);

    public static ApiResponse<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
        new( message,statusCode, default);
}