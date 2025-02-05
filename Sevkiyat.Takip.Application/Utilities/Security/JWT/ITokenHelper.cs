using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> claims);
}