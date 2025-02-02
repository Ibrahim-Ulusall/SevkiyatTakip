using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class IlanlarMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ilanlar",
                schema: "isletmeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alinacak_ulke_id = table.Column<int>(type: "integer", nullable: false),
                    alinacak_sehir_id = table.Column<int>(type: "integer", nullable: false),
                    alinacak_ilce_id = table.Column<int>(type: "integer", nullable: false),
                    teslim_edilecek_ulke_id = table.Column<int>(type: "integer", nullable: false),
                    teslim_edilecek_sehir_id = table.Column<int>(type: "integer", nullable: false),
                    teslim_edilecek_ilce_id = table.Column<int>(type: "integer", nullable: false),
                    firma_id = table.Column<int>(type: "integer", nullable: false),
                    yuk_tipi_id = table.Column<int>(type: "integer", nullable: false),
                    tasit_tipi_id = table.Column<int>(type: "integer", nullable: false),
                    kasa_tipi_id = table.Column<int>(type: "integer", nullable: false),
                    yuk_alim_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    on_gorülen_teslim_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    aciklama = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ilanlar_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ilanlar_firmalar_firma_id",
                        column: x => x.firma_id,
                        principalSchema: "isletmeler",
                        principalTable: "firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_alinacak_ilce_fk",
                        column: x => x.alinacak_ilce_id,
                        principalSchema: "bolgeler",
                        principalTable: "ilceler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_alinacak_sehir_fk",
                        column: x => x.alinacak_sehir_id,
                        principalSchema: "bolgeler",
                        principalTable: "sehirler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_alinacak_ulke_fk",
                        column: x => x.alinacak_ulke_id,
                        principalSchema: "bolgeler",
                        principalTable: "ulkeler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_kasa_tip_fk",
                        column: x => x.kasa_tipi_id,
                        principalSchema: "envanter",
                        principalTable: "kasa_tipleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_tasit_tip_fk",
                        column: x => x.tasit_tipi_id,
                        principalSchema: "envanter",
                        principalTable: "tasit_tipleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_teslim_edilecek_ilce_fk",
                        column: x => x.teslim_edilecek_ilce_id,
                        principalSchema: "bolgeler",
                        principalTable: "ilceler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_teslim_edilecek_sehir_fk",
                        column: x => x.teslim_edilecek_sehir_id,
                        principalSchema: "bolgeler",
                        principalTable: "sehirler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_teslim_edilecek_ulke_fk",
                        column: x => x.teslim_edilecek_ulke_id,
                        principalSchema: "bolgeler",
                        principalTable: "ulkeler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ilan_yuk_tip_fk",
                        column: x => x.yuk_tipi_id,
                        principalSchema: "envanter",
                        principalTable: "yuk_tipleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_alinacak_ilce_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_ilce_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_alinacak_sehir_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_sehir_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_alinacak_ulke_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_ulke_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_firma_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "firma_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_kasa_tipi_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "kasa_tipi_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_tasit_tipi_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "tasit_tipi_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_teslim_edilecek_ilce_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_ilce_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_teslim_edilecek_sehir_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_sehir_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_teslim_edilecek_ulke_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_ulke_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_yuk_tipi_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "yuk_tipi_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ilanlar",
                schema: "isletmeler");
        }
    }
}
