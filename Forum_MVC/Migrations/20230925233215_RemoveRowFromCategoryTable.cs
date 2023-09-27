using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum_MVC.Migrations
{
    public partial class RemoveRowFromCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AmountOfTopics", "Name", "VisibilityStatus" },
                values: new object[] { 15, 9, "Code Reviews and Feedback", "Suspended" });
        }
    }
}
