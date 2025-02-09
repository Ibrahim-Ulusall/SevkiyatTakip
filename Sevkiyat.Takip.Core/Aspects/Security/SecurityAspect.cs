using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sevkiyat.Takip.Core.Utilities.Helpers;
using Sevkiyat.Takip.Core.Utilities.Interceptors;
using Sevkiyat.Takip.Core.Extensions;
using Sevkiyat.Takip.Core.Models.Systems;

namespace Sevkiyat.Takip.Core.Aspects.Security;
public class SecurityAspect : MethodInterception
{
    private IHttpContextAccessor _httpContextAccessor;
    private string[] roles;
    public SecurityAspect(string role)
    {
        roles = role.Split(',');
        _httpContextAccessor = ServiceHelper.ServiceProvider?.GetService<IHttpContextAccessor>()!;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        foreach (var rol in roles)
            if (!roleClaims.Contains(rol))
                throw new SecurityExceptionModel("Yetkiniz yok");
    }
}
