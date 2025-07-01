using FlexPro.Client.Models;
using FlexPro.Client.Models.Request;
using FlexPro.Client.Models.Response;
using FlexPro.Client.Pages.Site.Contact;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IContactService
{
    Task<IEnumerable<ContactResponse>> GetAllAsync();
    Task<ApiResponse<string>> SaveAsync(ContatoRequest contact);
}