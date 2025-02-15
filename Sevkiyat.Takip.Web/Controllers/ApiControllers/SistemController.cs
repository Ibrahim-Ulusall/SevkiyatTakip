using Microsoft.AspNetCore.Mvc;
using Sevkiyat.Takip.Application.Models.Firmas;
using Sevkiyat.Takip.Application.Models.TasitTips;
using Sevkiyat.Takip.Application.Models.YulTips;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Models.Systems;
using Sevkiyat.Takip.Core.Utilities.Paging;
using Sevkiyat.Takip.Core.Utilities.Results;
using IResult = Sevkiyat.Takip.Core.Utilities.Results.IResult;

namespace Sevkiyat.Takip.Web.Controllers.ApiControllers;

/// <summary>
/// Yönetim Paneli ayarlarını yapan controller.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SistemController : ControllerBase
{
    private readonly ITasitTipRepository _tasitTipiRepository;
    private readonly IYukTipRepository _yukTipRepository;
    private readonly IFirmaRepository _firmaRepository;
    public SistemController(ITasitTipRepository tasitTipiRepository,
        IYukTipRepository yukTipRepository, IFirmaRepository firmaRepository)
    {
        _tasitTipiRepository = tasitTipiRepository;
        _yukTipRepository = yukTipRepository;
        _firmaRepository = firmaRepository;
    }


    /// <summary>
    /// Tasit Tipi oluşturur.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> CreateTasitTpiAsync([FromBody] CreateTasitTipiModel tasitTipi)
    {
        IResult result = await _tasitTipiRepository.CreateAsync(tasitTipi);
        return Ok(result);
    }

    /// <summary>
    /// Tasit Tipi Siler.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> DeleteTasitTipiAsync([FromRoute] int id)
    {
        IResult result = await _tasitTipiRepository.DeleteByIdAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Tasit Tipi Günceller.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> UpdateTasitTipAsync([FromBody] UpdateTasitTipiModel model)
    {
        IResult result = await _tasitTipiRepository.UpdateWithModelAsync(model);
        return Ok(result);
    }

    /// <summary>
    /// Id değeri verilen Tasit Tipini döner.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<GetTasitTipModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetTasitTipiAsync([FromRoute] int id)
    {
        IDataResult<GetTasitTipModel> result = await _tasitTipiRepository.GetByIdAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Tasit Tiplerini Listeler
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<GetTasitTipModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetListTasitTipiAsync()
    {
        IDataResult<ICollection<GetTasitTipModel>> result = await _tasitTipiRepository.GetAllAsync();
        return Ok(result);
    }

    /// <summary>
    /// Yük tipi oluşturur.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> CreateYukTipAsync([FromBody] CreateYukTipModel model)
    {
        IResult result = await _yukTipRepository.CreateAsync(model);
        return Ok(result);
    }

    /// <summary>
    /// Yük tipi siler.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> DeleteYukTipAsync([FromRoute] int id)
    {
        IResult result = await _yukTipRepository.RemoveAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Yük tipini günceller.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> UpdateYukTipAsync([FromBody] UpdateYukTipModel model)
    {
        IResult result = await _yukTipRepository.UpdateWithModelAsync(model);
        return Ok(result);
    }

    /// <summary>
    /// Id değeri verilen yük tipini döner.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<GetYukTipModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetYukTipAsync([FromRoute] int id)
    {
        IDataResult<GetYukTipModel> result = await _yukTipRepository.GetByIdAsync(id);
        return Ok(result);
    }


    /// <summary>
    /// Yük tiplerini döner.
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<GetYukTipModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetListYukTipAsync()
    {
        IDataResult<ICollection<GetYukTipModel>> result = await _yukTipRepository.GetAllAsync();
        return Ok(result);
    }


    /// <summary>
    /// Firma Oluşturur.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> CreateFirmaAsync([FromBody] CreateFirmaModel model)
    {
        IResult result = await _firmaRepository.CreateAsync(model);
        return Ok(result);
    }

    /// <summary>
    /// Firma Siler.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> DeleteFirmaAsync([FromRoute] int id)
    {
        IResult result = await _firmaRepository.RemoveAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Firma Günceller.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> UpdateFirmaAsync([FromBody] UpdateFirmaModel model)
    {
        IResult result = await _firmaRepository.EditAsync(model);
        return Ok(result);
    }

    /// <summary>
    /// Id değeri verilen firmanın detaylarını döner.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<FirmaDetayModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetFirmaAsync([FromRoute] int id)
    {
        IDataResult<FirmaDetayModel> result = await _firmaRepository.GetById(id);
        return Ok(result);
    }

    /// <summary>
    /// Firmaları listeler.
    /// </summary>
    /// <param name="adi"></param>
    /// <param name="index"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Paginate<FirmaDetayModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetListFirmaAsync([FromQuery] string? adi, int index = 1, int size = 10)
    {
        Paginate<FirmaDetayModel> firmas = await _firmaRepository.GetAllAsync(adi, index, size);
        return Ok(firmas);
    }


}
