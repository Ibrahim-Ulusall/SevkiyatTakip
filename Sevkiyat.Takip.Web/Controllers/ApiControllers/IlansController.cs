using Microsoft.AspNetCore.Mvc;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Validators.Ilans;
using Sevkiyat.Takip.Core.Utilities.Validation;

namespace Sevkiyat.Takip.Web.Controllers.ApiControllers;

/// <summary>
/// Ilanların yönetildiği controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class IlansController : ControllerBase
{
    private readonly IIlanRepository _ilanRepository;

    public IlansController(IIlanRepository ilanRepository)
    {
        _ilanRepository = ilanRepository;
    }

    /// <summary>
    /// Ilan oluşturur.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Create()
    {
        return Ok();
    }
}
