using Microsoft.EntityFrameworkCore.Migrations;

namespace databaseApp.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AC", "UserName" },
                values: new object[] { 12, "Baboon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creature",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AC", "UserName" },
                values: new object[] { 11, "Frog" });
        }
    }
}
