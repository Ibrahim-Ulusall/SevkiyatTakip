using System.ComponentModel;

namespace Sevkiyat.Takip.Core.Models.Auths;
public partial class LoginModel
{
    [DisplayName("Kullanıcı Adı")]
    public string Email { get; set; } = null!;
    [DisplayName("Parola")]
    public string Password { get; set; } = null!;
}
