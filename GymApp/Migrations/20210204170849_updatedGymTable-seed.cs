using Microsoft.EntityFrameworkCore.Migrations;

namespace GymApp.Migrations
{
    public partial class updatedGymTableseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id", "Address", "Description", "ImageUrl", "IsActive", "Name", "Website" },
                values: new object[] { 2, "Stawowa 16, Kraków", "Siłownia lepsza niż inne!", null, true, "Fitness Platinium", "fitnesplatinium.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
