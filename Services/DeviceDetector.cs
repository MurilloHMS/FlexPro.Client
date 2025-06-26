using Microsoft.JSInterop;

namespace FlexPro.Client.Services;

public class DeviceDetector
{
    private readonly IJSRuntime _js;

    public DeviceDetector(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<bool> IsMobileAsync()
    {
        return await _js.InvokeAsync<bool>("isMobile");
    }
}