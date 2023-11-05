using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerSurvey.Migrations
{
    public partial class CustomerSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSurveys",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    UniqueURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyNotificationDelivered = table.Column<bool>(type: "bit", nullable: false),
                    IsSurveyCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSurveys", x => new { x.CustomerID, x.SurveyID });
                    table.ForeignKey(
                        name: "FK_CustomerSurveys_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSurveys_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    QuestionCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OuestionID = table.Column<int>(type: "int", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_OuestionID",
                        column: x => x.OuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAnswers",
                columns: table => new
                {
                    CustomerAnswers = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAnswers", x => new { x.AnswerID, x.CustomerID, x.CustomerAnswers });
                    table.ForeignKey(
                        name: "FK_CustomerAnswers_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "AnswerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAnswers_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_OuestionID",
                table: "Answers",
                column: "OuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAnswers_CustomerID",
                table: "CustomerAnswers",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveys_SurveyID",
                table: "CustomerSurveys",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyID",
                table: "Questions",
                column: "SurveyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAnswers");

            migrationBuilder.DropTable(
                name: "CustomerSurveys");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
