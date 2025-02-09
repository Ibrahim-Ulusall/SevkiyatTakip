using AutoMapper;
using Sevkiyat.Takip.Application.Models.YulTips;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.MappingProfiles.YukTips;
public class YukTipMappingProfiles: Profile
{
    public YukTipMappingProfiles()
    {
        CreateMap<CreateYukTipModel, YukTip>().ReverseMap();
        CreateMap<UpdateYukTipModel, YukTip>().ReverseMap();
    }
}
