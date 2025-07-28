using System.Text.Json;
using FlexPro.Client.Domain.Models.Response;
using Microsoft.JSInterop;

namespace FlexPro.Client.Services;

public class CartService
{
    private const string CartKey = "cart";
    private readonly IJSRuntime _js;
    private List<ProdutoLojaResponse> _cart = new();

    public CartService(IJSRuntime js)
    {
        _js = js;
    }

    public event Action<int>? CartCountChanged;

    public async Task InitializeAsync()
    {
        var json = await _js.InvokeAsync<string>("localStorage.getItem", CartKey);
        _cart = string.IsNullOrEmpty(json)
            ? new List<ProdutoLojaResponse>()
            : JsonSerializer.Deserialize<List<ProdutoLojaResponse>>(json) ?? new List<ProdutoLojaResponse>();
        NotifyCountChanged();
    }

    public async Task AddToCartAsync(ProdutoLojaResponse produto)
    {
        _cart.Add(produto);
        await SaveCartAsync();
    }

    public async Task RemoveFromCartAsync(int index)
    {
        if (index >= 0 && index < _cart.Count)
        {
            _cart.RemoveAt(index);
            await SaveCartAsync();
        }
    }

    public async Task ClearAsync()
    {
        _cart.Clear();
        await _js.InvokeVoidAsync("localStorage.removeItem", CartKey);
        NotifyCountChanged();
    }

    public List<ProdutoLojaResponse> GetCart()
    {
        return _cart;
    }

    public int GetCartCount()
    {
        return _cart.Count;
    }

    private async Task SaveCartAsync()
    {
        var json = JsonSerializer.Serialize(_cart);
        await _js.InvokeVoidAsync("localStorage.setItem", CartKey, json);
        NotifyCountChanged();
    }

    private void NotifyCountChanged()
    {
        CartCountChanged?.Invoke(GetCartCount());
    }
}