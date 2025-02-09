using AutoMapper;
using Sevkiyat.Takip.Application.Models.Ilans;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.MappingProfiles.Ilans;
public class IlanMappingProfiles : Profile
{
    public IlanMappingProfiles()
    {
        CreateMap<CreateIlanModel, Ilan>().ReverseMap();
        CreateMap<UpdateIlanModel, Ilan>().ReverseMap();
    }
}
