using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UlkelerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "kod",
                schema: "bolgeler",
                table: "ulkeler",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefon_kodu",
                schema: "bolgeler",
                table: "ulkeler",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kod",
                schema: "bolgeler",
                table: "ulkeler");

            migrationBuilder.DropColumn(
                name: "telefon_kodu",
                schema: "bolgeler",
                table: "ulkeler");
        }
    }
}
