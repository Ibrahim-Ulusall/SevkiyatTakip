using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Models.Auths;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Web.Controllers.ApiControllers;

/// <summary>
/// Yetkilendirme yapan controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthsController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Kullanıcıların login olmasını sağlar
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel login)
    {
        return Ok(login);
    }
}
