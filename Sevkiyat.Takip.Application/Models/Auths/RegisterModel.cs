using Microsoft.AspNetCore.Http;

namespace Sevkiyat.Takip.Application.Models.Auths;

public class RegisterModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public IFormFile? Photo { get; set; }
}