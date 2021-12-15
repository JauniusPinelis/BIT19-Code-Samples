using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApplication.Migrations
{
    public partial class NewTodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 1, null, null, "Todo1" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 2, null, null, "Todo2" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[] { 3, null, null, "Todo3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Default" });
        }
    }
}
