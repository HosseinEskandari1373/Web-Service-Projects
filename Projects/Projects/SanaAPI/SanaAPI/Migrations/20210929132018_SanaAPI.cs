using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanaAPI.Migrations
{
    public partial class SanaAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    SiteDate = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                values: new object[,]
                {
                    { 1, "EUR", "یورو" },
                    { 2, "AED", "درهم امارات متحده عربی" },
                    { 3, "CNY", "یوان  چین" },
                    { 4, "INR", "روپیه  هند" },
                    { 5, "USD", "دلار آمریکا" },
                    { 6, "RUB", "روبل روسيه" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "TypeId", "PriceType", "TypeCurrency" },
                values: new object[,]
                {
                    { 1, "خرید", "اسکناس" },
                    { 2, "فروش", "اسکناس" },
                    { 3, "خرید", "حواله ارزی" },
                    { 4, "فروش", "حواله ارزی" },
                    { 5, "نرخ دولتی", "ارز دولتی" }
                });

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
