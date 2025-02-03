﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sevkiyat.Takip.Persistance.Contexts;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    [DbContext(typeof(SevkiyatContext))]
    [Migration("20250203063144_IlanlarDopColMigration")]
    partial class IlanlarDopColMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("adi");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("firmalar_pkey");

                    b.ToTable("firmalar", "isletmeler");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.FirmaTasit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<int>("FirmaId")
                        .HasColumnType("integer")
                        .HasColumnName("firma_id");

                    b.Property<int>("TasitTipId")
                        .HasColumnType("integer")
                        .HasColumnName("tasit_tip_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("firma_tasitlar_pkey");

                    b.HasIndex("FirmaId");

                    b.HasIndex("TasitTipId");

                    b.ToTable("firma_tasitlar", "isletmeler");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.FirmaYetkili", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<int>("FirmaId")
                        .HasColumnType("integer")
                        .HasColumnName("firma_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("firma_yetkililer_pkey");

                    b.HasIndex("FirmaId");

                    b.HasIndex("UserId");

                    b.ToTable("firma_yetkililer", "isletmeler");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Ilan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("text")
                        .HasColumnName("aciklama");

                    b.Property<int>("AlinacakIlceId")
                        .HasColumnType("integer")
                        .HasColumnName("alinacak_ilce_id");

                    b.Property<int>("AlinacakSehirId")
                        .HasColumnType("integer");

                    b.Property<int>("AlinacakUlkeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<int>("FirmaId")
                        .HasColumnType("integer")
                        .HasColumnName("firma_id");

                    b.Property<int>("KasaTipiId")
                        .HasColumnType("integer")
                        .HasColumnName("kasa_tipi_id");

                    b.Property<DateTime?>("OnGorulenTeslimTarihi")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("on_gorülen_teslim_tarihi");

                    b.Property<int>("TasitTipiId")
                        .HasColumnType("integer")
                        .HasColumnName("tasit_tipi_id");

                    b.Property<int>("TeslimEdilecekIlceId")
                        .HasColumnType("integer")
                        .HasColumnName("teslim_edilecek_ilce_id");

                    b.Property<int>("TeslimEdilecekSehirId")
                        .HasColumnType("integer");

                    b.Property<int>("TeslimEdilecekUlkeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<DateTime>("YukAlimTarihi")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("yuk_alim_tarihi");

                    b.Property<int>("YukTipiId")
                        .HasColumnType("integer")
                        .HasColumnName("yuk_tipi_id");

                    b.HasKey("Id")
                        .HasName("ilanlar_pkey");

                    b.HasIndex("AlinacakIlceId");

                    b.HasIndex("FirmaId");

                    b.HasIndex("KasaTipiId");

                    b.HasIndex("TasitTipiId");

                    b.HasIndex("TeslimEdilecekIlceId");

                    b.HasIndex("YukTipiId");

                    b.ToTable("ilanlar", "isletmeler");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Ilce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("SehirId")
                        .HasColumnType("integer")
                        .HasColumnName("sehir_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("ilceler_pkey");

                    b.HasIndex("SehirId");

                    b.ToTable("ilceler", "bolgeler");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.KasaTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("kasa_tipleri_pkey");

                    b.ToTable("kasa_tipleri", "envanter");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Sehir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("UlkeId")
                        .HasColumnType("integer")
                        .HasColumnName("ulke_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("sehirler_pkey");

                    b.HasIndex("UlkeId");

                    b.ToTable("sehirler", "bolgeler");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.TasitTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("tasit_tipleri_pkey");

                    b.ToTable("tasit_tipleri", "envanter");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Ulke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("ulkeler_pkey");

                    b.ToTable("ulkeler", "bolgeler");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.YukTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("yuk_tipleri_pkey");

                    b.ToTable("yuk_tipleri", "envanter");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.FirmaTasit", b =>
                {
                    b.HasOne("Sevkiyat.Takip.Domain.Entities.Firma", "Firma")
                        .WithMany("FirmaTasits")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("firma_firma_tasitlar_fk");

                    b.HasOne("Sevkiyat.Takip.Domain.Entities.TasitTip", "TasitTip")
                        .WithMany("FirmaTasits")
                        .HasForeignKey("TasitTipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("tasit_tip_firma_tasitlar_fk");

                    b.Navigation("Firma");

                    b.Navigation("TasitTip");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.FirmaYetkili", b =>
                {
                    b.HasOne("Sevkiyat.Takip.Domain.Entities.Firma", "Firma")
                        .WithMany("FirmaYetkilis")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("firma_firma_yetkili_fk");

                    b.HasOne("Sevkiyat.Takip.Domain.Entities.User", "User")
                        .WithMany("FirmaYetkilis")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_firma_yetkili_fk");

                    b.Navigation("Firma");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Ilan", b =>
                {
                    b.HasOne("Sevkiyat.Takip.Domain.Entities.Ilce", "AlinacakIlce")
                        .WithMany("AlinacakIlans")
                        .HasForeignKey("AlinacakIlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ilan_alinacak_ilce_fk");

                    b.HasOne("Sevkiyat.Takip.Domain.Entities.Firma", "Firma")
                        .WithMany("Ilans")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevkiyat.Takip.Domain.Entities.KasaTip", "KasaTip")
                        .WithMany("Ilans")
                        .HasForeignKey("KasaTipiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ilan_kasa_tip_fk");

                    b.HasOne("Sevkiyat.Takip.Domain.Entities.TasitTip", "TasitTip")
                        .WithMany("Ilans")
                        .HasForeignKey("TasitTipiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ilan_tasit_tip_fk");

                    b.HasOne("Sevkiyat.Takip.Domain.Entities.Ilce", "TeslimEdilecekIlce")
                        .WithMany("TeslimEdilecekIlans")
                        .HasForeignKey("TeslimEdilecekIlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ilan_teslim_edilecek_ilce_fk");

                    b.HasOne("Sevkiyat.Takip.Domain.Entities.YukTip", "YukTip")
                        .WithMany("Ilans")
                        .HasForeignKey("YukTipiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ilan_yuk_tip_fk");

                    b.Navigation("AlinacakIlce");

                    b.Navigation("Firma");

                    b.Navigation("KasaTip");

                    b.Navigation("TasitTip");

                    b.Navigation("TeslimEdilecekIlce");

                    b.Navigation("YukTip");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Ilce", b =>
                {
                    b.HasOne("Sevkiyat.Takip.Domain.Entities.Sehir", "Sehir")
                        .WithMany("Ilces")
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("sehir_ilce_fk");

                    b.Navigation("Sehir");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Sehir", b =>
                {
                    b.HasOne("Sevkiyat.Takip.Domain.Entities.Ulke", "Ulke")
                        .WithMany("Sehirs")
                        .HasForeignKey("UlkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ulke_sehir_fk");

                    b.Navigation("Ulke");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Firma", b =>
                {
                    b.Navigation("FirmaTasits");

                    b.Navigation("FirmaYetkilis");

                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Ilce", b =>
                {
                    b.Navigation("AlinacakIlans");

                    b.Navigation("TeslimEdilecekIlans");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.KasaTip", b =>
                {
                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Sehir", b =>
                {
                    b.Navigation("Ilces");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.TasitTip", b =>
                {
                    b.Navigation("FirmaTasits");

                    b.Navigation("Ilans");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.Ulke", b =>
                {
                    b.Navigation("Sehirs");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.User", b =>
                {
                    b.Navigation("FirmaYetkilis");
                });

            modelBuilder.Entity("Sevkiyat.Takip.Domain.Entities.YukTip", b =>
                {
                    b.Navigation("Ilans");
                });
#pragma warning restore 612, 618
        }
    }
}
