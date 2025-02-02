using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Sevkiyat.Takip.Domain.Entities;
using System;
using System.Reflection;

namespace Sevkiyat.Takip.Persistance.Contexts;
public class SevkiyatContext : DbContext
{
    public virtual DbSet<KasaTip> KasitTipleri { get; set; }
    public virtual DbSet<YukTip> YukTipleri { get; set; }
    public virtual DbSet<TasitTip> TasitTipleri { get; set; }

    public SevkiyatContext(DbContextOptions<SevkiyatContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
