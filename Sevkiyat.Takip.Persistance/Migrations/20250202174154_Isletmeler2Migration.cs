using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Isletmeler2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "firma_tasitlar",
                schema: "isletmeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firma_id = table.Column<int>(type: "integer", nullable: false),
                    tasit_tip_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("firma_tasitlar_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "firma_firma_tasitlar_fk",
                        column: x => x.firma_id,
                        principalSchema: "isletmeler",
                        principalTable: "firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tasit_tip_firma_tasitlar_fk",
                        column: x => x.tasit_tip_id,
                        principalSchema: "envanter",
                        principalTable: "tasit_tipleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "firma_yetkililer",
                schema: "isletmeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    firma_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("firma_yetkililer_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "firma_firma_yetkili_fk",
                        column: x => x.firma_id,
                        principalSchema: "isletmeler",
                        principalTable: "firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_firma_yetkili_fk",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_firma_tasitlar_firma_id",
                schema: "isletmeler",
                table: "firma_tasitlar",
                column: "firma_id");

            migrationBuilder.CreateIndex(
                name: "IX_firma_tasitlar_tasit_tip_id",
                schema: "isletmeler",
                table: "firma_tasitlar",
                column: "tasit_tip_id");

            migrationBuilder.CreateIndex(
                name: "IX_firma_yetkililer_firma_id",
                schema: "isletmeler",
                table: "firma_yetkililer",
                column: "firma_id");

            migrationBuilder.CreateIndex(
                name: "IX_firma_yetkililer_user_id",
                schema: "isletmeler",
                table: "firma_yetkililer",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "firma_tasitlar",
                schema: "isletmeler");

            migrationBuilder.DropTable(
                name: "firma_yetkililer",
                schema: "isletmeler");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
