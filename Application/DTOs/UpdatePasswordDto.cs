namespace FlexPro.Client.Application.DTOs;

public class UpdatePasswordDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}