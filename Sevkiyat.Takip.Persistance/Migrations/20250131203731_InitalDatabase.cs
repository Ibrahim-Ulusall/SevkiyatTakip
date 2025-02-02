using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitalDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "envanter");

            migrationBuilder.CreateTable(
                name: "kasa_tipleri",
                schema: "envanter",
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
                    table.PrimaryKey("kasa_tipleri_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasit_tipleri",
                schema: "envanter",
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
                    table.PrimaryKey("tasit_tipleri_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "yuk_tipleri",
                schema: "envanter",
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
                    table.PrimaryKey("yuk_tipleri_pkey", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kasa_tipleri",
                schema: "envanter");

            migrationBuilder.DropTable(
                name: "tasit_tipleri",
                schema: "envanter");

            migrationBuilder.DropTable(
                name: "yuk_tipleri",
                schema: "envanter");
        }
    }
}
