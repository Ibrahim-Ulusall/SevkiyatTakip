using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sevkiyat.Takip.Core.Models.Auths;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Web.Controllers.ApiControllers;

/// <summary>
/// Yetkilendirme yapan controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public AuthsController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Kullanıcıyı login eder.
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);

        var user = await _userManager.FindByNameAsync(login.Username);

        return Ok(user);
    }
}
