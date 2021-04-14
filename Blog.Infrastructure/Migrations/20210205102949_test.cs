using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiketler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SilId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiketler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GenelAyarlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logo_url = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    favicon = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenelAyarlar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IletisimBilgileri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aciklama = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true),
                    eposta = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    telefon = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    adres = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    harita = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimBilgileri", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    url_ad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    renk_kodu = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    yazi_sayisi = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    SilId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kategoriler_Kategoriler_parent_id",
                        column: x => x.parent_id,
                        principalTable: "Kategoriler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostaKutusu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    soyad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    konu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    mesaj = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true),
                    ip_adresi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    onay_durumu_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    SilId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostaKutusu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReklamAlanlari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alan_adi = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    aciklama = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    kodu = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReklamAlanlari", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sayfalar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    url_baslik = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    icerik = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    one_cikan_gorsel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    onay_durumu_id = table.Column<int>(type: "int", nullable: false),
                    SilId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sayfalar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SeoAyarlari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    title = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    keywords = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    analytics = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeoAyarlari", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SosyalMedya",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facebook = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Twitter = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    instagram = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Youtube = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalMedya", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Job = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    About = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yazilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    url_baslik = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    icerik = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    one_cikan_gorsel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    one_cikan = table.Column<int>(type: "int", nullable: false),
                    onay_durumu_id = table.Column<int>(type: "int", nullable: false),
                    okunma_sayisi = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SilId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazilar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Yazilar_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtiketYazilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yazi_id = table.Column<int>(type: "int", nullable: true),
                    etiket_id = table.Column<int>(type: "int", nullable: true),
                    SilId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiketYazilar", x => x.id);
                    table.ForeignKey(
                        name: "FK_EtiketYazilar_Etiketler_etiket_id",
                        column: x => x.etiket_id,
                        principalTable: "Etiketler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EtiketYazilar_Yazilar_yazi_id",
                        column: x => x.yazi_id,
                        principalTable: "Yazilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KategoriYazilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yazi_id = table.Column<int>(type: "int", nullable: false),
                    kategori_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriYazilar", x => x.id);
                    table.ForeignKey(
                        name: "FK_KategoriYazilar_Kategoriler_kategori_id",
                        column: x => x.kategori_id,
                        principalTable: "Kategoriler",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategoriYazilar_Yazilar_yazi_id",
                        column: x => x.yazi_id,
                        principalTable: "Yazilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad_soyad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    website = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    yorum = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    cevaplanan_yorum_id = table.Column<int>(type: "int", nullable: true),
                    ip_adres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    onay_durumu_id = table.Column<int>(type: "int", nullable: false),
                    yazi_id = table.Column<int>(type: "int", nullable: true),
                    SilId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Yazilar_yazi_id",
                        column: x => x.yazi_id,
                        principalTable: "Yazilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Yorumlar_cevaplanan_yorum_id",
                        column: x => x.cevaplanan_yorum_id,
                        principalTable: "Yorumlar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtiketYazilar_etiket_id",
                table: "EtiketYazilar",
                column: "etiket_id");

            migrationBuilder.CreateIndex(
                name: "IX_EtiketYazilar_yazi_id",
                table: "EtiketYazilar",
                column: "yazi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_parent_id",
                table: "Kategoriler",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriYazilar_kategori_id",
                table: "KategoriYazilar",
                column: "kategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriYazilar_yazi_id",
                table: "KategoriYazilar",
                column: "yazi_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yazilar_UserId",
                table: "Yazilar",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_cevaplanan_yorum_id",
                table: "Yorumlar",
                column: "cevaplanan_yorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_yazi_id",
                table: "Yorumlar",
                column: "yazi_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtiketYazilar");

            migrationBuilder.DropTable(
                name: "GenelAyarlar");

            migrationBuilder.DropTable(
                name: "IletisimBilgileri");

            migrationBuilder.DropTable(
                name: "KategoriYazilar");

            migrationBuilder.DropTable(
                name: "PostaKutusu");

            migrationBuilder.DropTable(
                name: "ReklamAlanlari");

            migrationBuilder.DropTable(
                name: "Sayfalar");

            migrationBuilder.DropTable(
                name: "SeoAyarlari");

            migrationBuilder.DropTable(
                name: "SosyalMedya");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Etiketler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Yazilar");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
