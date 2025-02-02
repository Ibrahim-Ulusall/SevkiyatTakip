using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;

public class Firma : BaseEntity<int>
{
    public string Adi { get; set; } = null!;
    public virtual ICollection<FirmaYetkili> FirmaYetkilis { get; set; }
    public virtual ICollection<FirmaTasit> FirmaTasits { get; set; }
    public virtual ICollection<Ilan> Ilans { get; set; }
    public Firma()
    {
        FirmaYetkilis = new List<FirmaYetkili>();
        FirmaTasits = new List<FirmaTasit>();
        Ilans = new List<Ilan>();
    }
    public Firma(string adi, ICollection<FirmaYetkili> firmaYetkilis,
        ICollection<FirmaTasit> firmaTasits,ICollection<Ilan> ilans)
    {
        Adi = adi;
        FirmaYetkilis = firmaYetkilis;
        FirmaTasits = firmaTasits;
        Ilans = ilans;
    }
}
