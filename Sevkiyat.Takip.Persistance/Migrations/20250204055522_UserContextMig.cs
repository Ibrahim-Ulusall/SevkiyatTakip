using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sevkiyat.Takip.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UserContextMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "isletmeler");

            migrationBuilder.EnsureSchema(
                name: "bolgeler");

            migrationBuilder.EnsureSchema(
                name: "envanter");

            migrationBuilder.EnsureSchema(
                name: "accounts");

            migrationBuilder.CreateTable(
                name: "firmalar",
                schema: "isletmeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("firmalar_pkey", x => x.Id);
                });

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
                name: "roles",
                schema: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.id);
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
                name: "token_types",
                schema: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adi = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("token_types_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ulkeler",
                schema: "bolgeler",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    kod = table.Column<string>(type: "text", nullable: false, defaultValueSql: "''::text"),
                    telefon_kodu = table.Column<string>(type: "text", nullable: false, defaultValueSql: "''::text"),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ulkeler_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    password_salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    last_page = table.Column<string>(type: "text", nullable: true),
                    token = table.Column<string>(type: "text", nullable: true),
                    token_expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    ignore_two_factor = table.Column<bool>(type: "boolean", nullable: false),
                    photo = table.Column<string>(type: "text", nullable: true),
                    forgot_password_token = table.Column<string>(type: "text", nullable: true),
                    forgot_password_token_expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "operation_claims",
                schema: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_claims", x => x.id);
                    table.ForeignKey(
                        name: "operation_claims_role_id_fkey",
                        column: x => x.role_id,
                        principalSchema: "accounts",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalSchema: "accounts",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                schema: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_roles_pkey", x => x.id);
                    table.ForeignKey(
                        name: "user_roles_role_id_fkey",
                        column: x => x.role_id,
                        principalSchema: "accounts",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_roles_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "accounts",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                schema: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    token_type_id = table.Column<int>(type: "integer", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_tokens_pkey", x => x.id);
                    table.ForeignKey(
                        name: "user_tokens_token_type_id_fkey",
                        column: x => x.token_type_id,
                        principalSchema: "accounts",
                        principalTable: "token_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_tokens_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "accounts",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_operation_claims",
                schema: "accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operation_claim_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_operation_claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_operation_claims_operation_claims_operation_claim_id",
                        column: x => x.operation_claim_id,
                        principalSchema: "accounts",
                        principalTable: "operation_claims",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_operation_claims_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "accounts",
                        principalTable: "users",
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

            migrationBuilder.CreateTable(
                name: "ilanlar",
                schema: "isletmeler",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alinacak_ilce_id = table.Column<int>(type: "integer", nullable: false),
                    firma_id = table.Column<int>(type: "integer", nullable: false),
                    yuk_tipi_id = table.Column<int>(type: "integer", nullable: false),
                    tasit_tipi_id = table.Column<int>(type: "integer", nullable: false),
                    kasa_tipi_id = table.Column<int>(type: "integer", nullable: false),
                    yuk_alim_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    on_gorülen_teslim_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    aciklama = table.Column<string>(type: "text", nullable: true),
                    teslim_ilce_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ilanlar_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_ilanlar_firmalar_firma_id",
                        column: x => x.firma_id,
                        principalSchema: "isletmeler",
                        principalTable: "firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ilanlar_ilceler_alinacak_ilce_id",
                        column: x => x.alinacak_ilce_id,
                        principalSchema: "bolgeler",
                        principalTable: "ilceler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ilanlar_ilceler_teslim_ilce_id",
                        column: x => x.teslim_ilce_id,
                        principalSchema: "bolgeler",
                        principalTable: "ilceler",
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
                        name: "ilan_yuk_tip_fk",
                        column: x => x.yuk_tipi_id,
                        principalSchema: "envanter",
                        principalTable: "yuk_tipleri",
                        principalColumn: "id",
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

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_alinacak_ilce_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "alinacak_ilce_id");

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
                name: "IX_ilanlar_teslim_ilce_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "teslim_ilce_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_yuk_tipi_id",
                schema: "isletmeler",
                table: "ilanlar",
                column: "yuk_tipi_id");

            migrationBuilder.CreateIndex(
                name: "IX_ilceler_sehir_id",
                schema: "bolgeler",
                table: "ilceler",
                column: "sehir_id");

            migrationBuilder.CreateIndex(
                name: "IX_operation_claims_role_id",
                schema: "accounts",
                table: "operation_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_sehirler_ulke_id",
                schema: "bolgeler",
                table: "sehirler",
                column: "ulke_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_operation_claims_operation_claim_id",
                schema: "accounts",
                table: "user_operation_claims",
                column: "operation_claim_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_operation_claims_user_id",
                schema: "accounts",
                table: "user_operation_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                schema: "accounts",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_user_id",
                schema: "accounts",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_tokens_token_type_id",
                schema: "accounts",
                table: "user_tokens",
                column: "token_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_tokens_user_id",
                schema: "accounts",
                table: "user_tokens",
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
                name: "ilanlar",
                schema: "isletmeler");

            migrationBuilder.DropTable(
                name: "user_operation_claims",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "user_roles",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "user_tokens",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "firmalar",
                schema: "isletmeler");

            migrationBuilder.DropTable(
                name: "ilceler",
                schema: "bolgeler");

            migrationBuilder.DropTable(
                name: "kasa_tipleri",
                schema: "envanter");

            migrationBuilder.DropTable(
                name: "tasit_tipleri",
                schema: "envanter");

            migrationBuilder.DropTable(
                name: "yuk_tipleri",
                schema: "envanter");

            migrationBuilder.DropTable(
                name: "operation_claims",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "token_types",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "users",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "sehirler",
                schema: "bolgeler");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "ulkeler",
                schema: "bolgeler");
        }
    }
}
