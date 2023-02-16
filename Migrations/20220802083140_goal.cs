using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace get_fit.Migrations
{
    public partial class goal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Trainee_information",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Trainee_information");
        }
    }
}
