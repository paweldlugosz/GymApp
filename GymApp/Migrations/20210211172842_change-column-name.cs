using Microsoft.EntityFrameworkCore.Migrations;

namespace GymApp.Migrations
{
    public partial class changecolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "GymOpinions");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "GymOpinions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "GymOpinions");

            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "GymOpinions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
