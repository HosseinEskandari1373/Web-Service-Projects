using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanaRate_Scrapper.Migrations
{
    public partial class SanaScrapper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrencyName = table.Column<string>(type: "TEXT", nullable: true),
                    CurrencyCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeCurrency = table.Column<string>(type: "TEXT", nullable: true),
                    PriceType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    SiteDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    CurrencyId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => new { x.CurrencyId, x.TypeId, x.SiteDate });
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_CurrencyTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyCode", "CurrencyName" },
                values: new object[] { 1, "EUR", "یورو" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyCode", "CurrencyName" },
                values: new object[] { 2, "AED", "درهم امارات متحده عربی" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyCode", "CurrencyName" },
                values: new object[] { 3, "CNY", "یوان  چین" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyCode", "CurrencyName" },
                values: new object[] { 4, "INR", "روپیه  هند" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyCode", "CurrencyName" },
                values: new object[] { 5, "USD", "دلار آمریکا" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyCode", "CurrencyName" },
                values: new object[] { 6, "RUB", "روبل روسيه" });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "TypeId", "PriceType", "TypeCurrency" },
                values: new object[] { 1, "خرید", "اسکناس" });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "TypeId", "PriceType", "TypeCurrency" },
                values: new object[] { 2, "فروش", "اسکناس" });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "TypeId", "PriceType", "TypeCurrency" },
                values: new object[] { 3, "خرید", "حواله ارزی" });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "TypeId", "PriceType", "TypeCurrency" },
                values: new object[] { 4, "فروش", "حواله ارزی" });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_TypeId",
                table: "CurrencyRates",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");
        }
    }
}
