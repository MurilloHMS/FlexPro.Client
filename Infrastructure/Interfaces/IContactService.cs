using FlexPro.Client.Domain.Models;
using FlexPro.Client.Domain.Models.Request;
using FlexPro.Client.Domain.Models.Response;
using FlexPro.Client.Pages.Site.Contact;

namespace FlexPro.Client.Infrastructure.Interfaces;

public interface IContactService
{
    Task<IEnumerable<ContactResponse>> GetAllAsync();
    Task<ApiResponse<string>> SaveAsync(ContatoRequest contact);
}