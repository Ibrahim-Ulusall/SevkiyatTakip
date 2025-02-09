using AutoMapper;
using Sevkiyat.Takip.Application.Models.TasitTips;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.MappingProfiles.TasitTips;
public class TasitTipMappingProfiles: Profile
{
    public TasitTipMappingProfiles()
    {
        CreateMap<TasitTip, CreateTasitTipiModel>().ReverseMap();
        CreateMap<TasitTip, UpdateTasitTipiModel>().ReverseMap();
    }
}
