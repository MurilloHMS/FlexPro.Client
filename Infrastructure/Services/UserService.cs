namespace FlexPro.Client.Services;

public class UserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }
    
}