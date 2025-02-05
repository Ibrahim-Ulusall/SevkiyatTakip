using Sevkiyat.Takip.Application.Services;

namespace Sevkiyat.Takip.Persistance.Services;
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


}
