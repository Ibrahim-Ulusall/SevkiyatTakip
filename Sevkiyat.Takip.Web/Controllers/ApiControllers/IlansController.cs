using Microsoft.AspNetCore.Mvc;
using Sevkiyat.Takip.Application.Models.Ilans;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Models.Systems;
using Sevkiyat.Takip.Core.Utilities.Paging;
using Sevkiyat.Takip.Core.Utilities.Results;
using IResult = Sevkiyat.Takip.Core.Utilities.Results.IResult;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationFailureErrors))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> CreateAsync([FromBody] CreateIlanModel ilan)
    {
        IResult result = await _ilanRepository.CreateAsync(ilan);
        return Ok(result);
    }

    /// <summary>
    /// Ilan siler.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        IResult result = await _ilanRepository.RemoveAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// İlanı günceller.
    /// </summary>
    /// <param name="ilan"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateIlanModel ilan)
    {
        IResult result = await _ilanRepository.UpdateAsync(ilan);
        return Ok(ilan);
    }

    /// <summary>
    /// Id değeri verilen ilanı döner.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<GetIlanModel>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        IDataResult<GetIlanModel> ilan = await _ilanRepository.GetAsync(id);
        return Ok(ilan);
    }

    /// <summary>
    /// İlanları listeler.
    /// </summary>
    /// <param name="alinacakIlceId"></param>
    /// <param name="teslimIlceId"></param>
    /// <param name="firmaId"></param>
    /// <param name="yukTipiId"></param>
    /// <param name="tasitTipiId"></param>
    /// <param name="kasaTipiId"></param>
    /// <param name="yukAlimTarihiBaslangic"></param>
    /// <param name="yukAlimTarihiBitis"></param>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Paginate<GetIlanModel>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetail))]
    public async Task<IActionResult> GetListAsync(int? alinacakIlceId, int? teslimIlceId, int? firmaId,
        int? yukTipiId, int? tasitTipiId, int? kasaTipiId, DateTime? yukAlimTarihiBaslangic, DateTime? yukAlimTarihiBitis,
        int page = 1, int size = 10)
    {
        Paginate<GetIlanModel> ilans = await _ilanRepository.GetListForPaginateAsync(alinacakIlceId, teslimIlceId, firmaId, yukTipiId, tasitTipiId,
            kasaTipiId, yukAlimTarihiBaslangic, yukAlimTarihiBitis, page, size);

        return Ok(ilans);
    }
}
