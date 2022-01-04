using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationForm.Migrations
{
    public partial class Moredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerId", "FormId", "Title" },
                values: new object[,]
                {
                    { 2, null, 1, "Rangos darbus atliks" },
                    { 3, null, 1, "Verslo klientas" },
                    { 4, null, 1, "Skaiciavimo metodas" },
                    { 5, null, 1, "Svarbus klientas" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "Title" },
                values: new object[,]
                {
                    { 3, 2, "Metinis Rangovas" },
                    { 4, 2, "Menesinis Rangovas" },
                    { 5, 3, "Taip" },
                    { 6, 3, "Ne" },
                    { 7, 4, "Automatinis" },
                    { 8, 4, "Manual" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
