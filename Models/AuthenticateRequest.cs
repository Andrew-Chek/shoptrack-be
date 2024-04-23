using System.ComponentModel;
using shoptrack_be.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        Id = user.UserId;
        Username = user.Username;
        Role = user.Role;
        Token = token;
    }
}

public class AuthenticateRequest
{
    [DefaultValue("System")]
    public required string Username { get; set; }

    [DefaultValue("System")]
    public required string Password { get; set; }
}
