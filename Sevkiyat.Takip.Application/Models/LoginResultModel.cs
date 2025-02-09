using Sevkiyat.Takip.Application.Utilities.Security.JWT;

namespace Sevkiyat.Takip.Application.Models;
public class LoginResultModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public Guid UserId { get; set; }
    public AccessToken? AccessToken { get; set; }
}
