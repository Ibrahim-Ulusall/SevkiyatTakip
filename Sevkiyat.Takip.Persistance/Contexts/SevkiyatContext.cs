using Microsoft.EntityFrameworkCore;
using Sevkiyat.Takip.Domain.Entities;
using System.Reflection;

namespace Sevkiyat.Takip.Persistance.Contexts;
public class SevkiyatContext : DbContext
{
    public virtual DbSet<KasaTip> KasitTipleri { get; set; }
    public virtual DbSet<YukTip> YukTipleri { get; set; }
    public virtual DbSet<TasitTip> TasitTipleri { get; set; }
    public virtual DbSet<Firma> Firmas { get; set; }
    public virtual DbSet<FirmaYetkili> FirmaYetkilis { get; set; }
    public virtual DbSet<FirmaTasit> FirmaTasits { get; set; }
    public virtual DbSet<Ulke> Ulkes { get; set; }
    public virtual DbSet<Sehir> Sehirs { get; set; }
    public virtual DbSet<Ilce> Ilces { get; set; }
    public virtual DbSet<Ilan> Ilans { get; set; }

    public SevkiyatContext(DbContextOptions<SevkiyatContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
