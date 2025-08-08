namespace FlexPro.Client.Application.DTOs;

public class UpdateUserModel
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public required IEnumerable<string> Roles { get; set; }
}
