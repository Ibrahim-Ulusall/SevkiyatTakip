using Microsoft.AspNetCore.Mvc;
using Sevkiyat.Takip.Application.Models.Auths;
using Sevkiyat.Takip.Application.Models.OperationClaims;
using Sevkiyat.Takip.Application.Models.Roles;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Models.Auths;
using Sevkiyat.Takip.Core.Models.Systems;
using IResult = Sevkiyat.Takip.Core.Utilities.Results.IResult;
namespace Sevkiyat.Takip.Web.Controllers.ApiControllers;

/// <summary>
/// Yetkilendirme yapan controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly IOperationClaimRepository _operationClaimRepository;
    public AuthsController(IUserRepository userRepository,
        IAuthService authService, IRoleRepository roleRepository,
        IOperationClaimRepository operationClaimRepository)
    {
        _userRepository = userRepository;
        _authService = authService;
        _roleRepository = roleRepository;
        _operationClaimRepository = operationClaimRepository;
    }

    /// <summary>
    /// Kullanıcıların login olmasını sağlar
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResultModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    public async Task<IActionResult> Register([FromForm] RegisterModel register)
    {
        var result = await _authService.Register(register);
        return Ok(result);
    }

    /// <summary>
    /// Rol oluşturur.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> AddRoleAsync([FromBody] CreateRoleModel model)
    {
        IResult result = await _roleRepository.CreateAsync(model);
        return Ok(result);
    }

    /// <summary>
    /// Rol Siler.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    public async Task<IActionResult> DeleteRoleAsync([FromRoute] int id)
    {
        IResult result = await _roleRepository.RemoveAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Claim Oluşturur.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    public async Task<IActionResult> CreateClaimAsync([FromBody] CreateOperationClaimModel model)
    {
        IResult result = await _operationClaimRepository.CreateAsync(model);
        return Ok(result);
    }

    /// <summary>
    /// Claim Siler.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    public async Task<IActionResult> DeleteClaimAsync([FromRoute] Guid id)
    {
        IResult result = await _operationClaimRepository.RemoveAsync(id);
        return Ok(result);
    }


}
