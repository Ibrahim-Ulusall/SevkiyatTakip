﻿using Microsoft.AspNetCore.Mvc;
using Sevkiyat.Takip.Application.Models;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.Auths;
using Sevkiyat.Takip.Core.Aspects;
using Sevkiyat.Takip.Core.Models.Auths;
using Sevkiyat.Takip.Core.Utilities.Validation;
using System.Configuration;

namespace Sevkiyat.Takip.Web.Controllers.ApiControllers;

/// <summary>
/// Yetkilendirme yapan controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    public AuthsController(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    /// <summary>
    /// Kullanıcıların login olmasını sağlar
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResultModel))]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel login)
    {
        var loginCheck = await _authService.Login(login);
        return Ok(loginCheck);
    }

    /// <summary>
    /// Kullanıcı oluşturur.
    /// </summary>
    /// <param name="register"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Core.Utilities.Results.IResult))]
    public async Task<IActionResult> Register([FromForm] RegisterModel register)
    {
        var result = await _authService.Register(register);
        return Ok(result);
    }
}
