namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IRouteHelper
{
    Task<Dictionary<string, string>> GetRoutesAsync();
}