using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class BolgelerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bolgeler");

            migrationBuilder.CreateTable(
                name: "ulkeler",
                schema: "bolgeler",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ulkeler_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sehirler",
                schema: "bolgeler",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ulke_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sehirler_pkey", x => x.id);
                    table.ForeignKey(
                        name: "ulke_sehir_fk",
                        column: x => x.ulke_id,
                        principalSchema: "bolgeler",
                        principalTable: "ulkeler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ilceler",
                schema: "bolgeler",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    sehir_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ilceler_pkey", x => x.id);
                    table.ForeignKey(
                        name: "sehir_ilce_fk",
                        column: x => x.sehir_id,
                        principalSchema: "bolgeler",
                        principalTable: "sehirler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ilceler_sehir_id",
                schema: "bolgeler",
                table: "ilceler",
                column: "sehir_id");

            migrationBuilder.CreateIndex(
                name: "IX_sehirler_ulke_id",
                schema: "bolgeler",
                table: "sehirler",
                column: "ulke_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ilceler",
                schema: "bolgeler");

            migrationBuilder.DropTable(
                name: "sehirler",
                schema: "bolgeler");

            migrationBuilder.DropTable(
                name: "ulkeler",
                schema: "bolgeler");
        }
    }
}
