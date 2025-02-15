using Sevkiyat.Takip.Application.Models.FirmaTasits;
using Sevkiyat.Takip.Application.Models.FirmaYetkilis;

namespace Sevkiyat.Takip.Application.Models.Firmas;

public class FirmaDetayModel
{
    public int Id { get; set; }
    public string Adi { get; set; } = null!;
    public ICollection<FirmaYetkiliDetayModel> FirmaYetkilis { get; set; }
    public ICollection<FirmaTasitDetayModel> FirmaTasits { get; set; }
    public FirmaDetayModel()
    {
        FirmaYetkilis = new List<FirmaYetkiliDetayModel>();
        FirmaTasits = new List<FirmaTasitDetayModel>();
    }

    public FirmaDetayModel(int ıd, string adi, ICollection<FirmaYetkiliDetayModel> firmaYetkilis,
        ICollection<FirmaTasitDetayModel> firmaTasits)
    {
        Id = ıd;
        Adi = adi;
        FirmaYetkilis = firmaYetkilis;
        FirmaTasits = firmaTasits;
    }
}