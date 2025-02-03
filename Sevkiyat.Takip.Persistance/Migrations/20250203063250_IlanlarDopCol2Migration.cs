using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class IlanlarDopCol2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlinacakSehirId",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropColumn(
                name: "AlinacakUlkeId",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropColumn(
                name: "TeslimEdilecekSehirId",
                schema: "isletmeler",
                table: "ilanlar");

            migrationBuilder.DropColumn(
                name: "TeslimEdilecekUlkeId",
                schema: "isletmeler",
                table: "ilanlar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlinacakSehirId",
                schema: "isletmeler",
                table: "ilanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlinacakUlkeId",
                schema: "isletmeler",
                table: "ilanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeslimEdilecekSehirId",
                schema: "isletmeler",
                table: "ilanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeslimEdilecekUlkeId",
                schema: "isletmeler",
                table: "ilanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
