using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sevkiyat.Takip.Application.Utilities.Security.Encryption;
using Sevkiyat.Takip.Core.Extensions;
using Sevkiyat.Takip.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sevkiyat.Takip.Application.Utilities.Security.JWT;
public class JwtHelper : ITokenHelper
{
    private readonly TokenOptions _tokenOptions;
    private readonly IConfiguration _configuration;
    private DateTime _accessTokenExpiration;
    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection(nameof(TokenOptions)).Get<TokenOptions>()
                        ?? throw new ArgumentNullException($"{nameof(configuration)} in appsettings.json not found");
    }

    public AccessToken CreateToken(User user, ICollection<OperationClaim> claims)
    {
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        JwtSecurityToken token = CreateJwtToken(signingCredentials, _tokenOptions, user, claims);

        return new AccessToken
        {
            Expiration = _accessTokenExpiration,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        };
    }

    public JwtSecurityToken CreateJwtToken(SigningCredentials signingCredentials, TokenOptions tokenOptions, User user, ICollection<OperationClaim> operationClaims)
    {
        JwtSecurityToken token = new JwtSecurityToken(
            audience: tokenOptions.Audience,
            issuer: tokenOptions.Issuer,
            notBefore: DateTime.Now,
            expires: _accessTokenExpiration,
            signingCredentials: signingCredentials,
            claims: SetClaims(user, operationClaims)
            );

        return token;
    }

    public IEnumerable<Claim> SetClaims(User user, ICollection<OperationClaim> claims)
    {
        IList<Claim> _claims = new List<Claim>();
        _claims.AddNameIdentifier(user.Id.ToString());
        _claims.AddEmail(user.Email);
        _claims.AddFullName(user.FullName);
        _claims.AddName(user.FirstName!);
        _claims.AddSurname(user.LastName!);
        _claims.AddRoles(claims.Select(i => i.Name!).ToArray());

        return _claims;
    }
}
