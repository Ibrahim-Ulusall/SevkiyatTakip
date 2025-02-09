using Sevkiyat.Takip.Application.Models;
using Sevkiyat.Takip.Core.Models.Auths;
using Sevkiyat.Takip.Core.Utilities.Results;

namespace Sevkiyat.Takip.Application.Services;
public interface IAuthService
{
    Task<LoginResultModel> Login(LoginModel login);
    Task<IResult> Register(RegisterModel register);
}
