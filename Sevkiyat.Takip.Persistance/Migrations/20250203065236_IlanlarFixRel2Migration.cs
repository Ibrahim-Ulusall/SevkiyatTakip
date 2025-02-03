using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class IlanlarFixRel2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ilan_alinacak_ilce_fk",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropForeignKey(
                name: "ilan_teslim_edilecek_ilce_fk",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.AddForeignKey(
                name: "FK_ilanlar_ilceler_alinacak_ilce_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_ilce_id",
                principalSchema: "bolgeler",
                principalTable: "ilceler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ilanlar_ilceler_teslim_edilecek_ilce_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_ilce_id",
                principalSchema: "bolgeler",
                principalTable: "ilceler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ilanlar_ilceler_alinacak_ilce_id",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_ilanlar_ilceler_teslim_edilecek_ilce_id",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.AddForeignKey(
                name: "ilan_alinacak_ilce_fk",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_ilce_id",
                principalSchema: "bolgeler",
                principalTable: "ilceler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ilan_teslim_edilecek_ilce_fk",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_ilce_id",
                principalSchema: "bolgeler",
                principalTable: "ilceler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
