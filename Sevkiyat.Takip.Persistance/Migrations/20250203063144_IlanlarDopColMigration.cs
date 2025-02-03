using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class IlanlarDopColMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ilan_alinacak_sehir_fk",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropForeignKey(
                name: "ilan_alinacak_ulke_fk",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropForeignKey(
                name: "ilan_teslim_edilecek_sehir_fk",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropForeignKey(
                name: "ilan_teslim_edilecek_ulke_fk",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropIndex(
                name: "IX_ilanlar_alinacak_sehir_id",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropIndex(
                name: "IX_ilanlar_alinacak_ulke_id",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropIndex(
                name: "IX_ilanlar_teslim_edilecek_sehir_id",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropIndex(
                name: "IX_ilanlar_teslim_edilecek_ulke_id",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "teslim_edilecek_ulke_id",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "TeslimEdilecekUlkeId");

            migrationBuilder.RenameColumn(
                name: "teslim_edilecek_sehir_id",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "TeslimEdilecekSehirId");

            migrationBuilder.RenameColumn(
                name: "alinacak_ulke_id",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "AlinacakUlkeId");

            migrationBuilder.RenameColumn(
                name: "alinacak_sehir_id",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "AlinacakSehirId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TeslimEdilecekUlkeId",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "teslim_edilecek_ulke_id");

            migrationBuilder.RenameColumn(
                name: "TeslimEdilecekSehirId",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "teslim_edilecek_sehir_id");

            migrationBuilder.RenameColumn(
                name: "AlinacakUlkeId",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "alinacak_ulke_id");

            migrationBuilder.RenameColumn(
                name: "AlinacakSehirId",
                schema: "isletmeler",
                table: "ilanlar",
                newName: "alinacak_sehir_id");

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
                name: "IX_ilanlar_teslim_edilecek_sehir_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_sehir_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_teslim_edilecek_ulke_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_ulke_id");

            migrationBuilder.AddForeignKey(
                name: "ilan_alinacak_sehir_fk",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_sehir_id",
                principalSchema: "bolgeler",
                principalTable: "sehirler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ilan_alinacak_ulke_fk",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_ulke_id",
                principalSchema: "bolgeler",
                principalTable: "ulkeler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ilan_teslim_edilecek_sehir_fk",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_sehir_id",
                principalSchema: "bolgeler",
                principalTable: "sehirler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ilan_teslim_edilecek_ulke_fk",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_edilecek_ulke_id",
                principalSchema: "bolgeler",
                principalTable: "ulkeler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
