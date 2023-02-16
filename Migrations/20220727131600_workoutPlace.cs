using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace get_fit.Migrations
{
    public partial class workoutPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkoutPlace",
                table: "Trainee_information",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutPlace",
                table: "Trainee_information");
        }
    }
}
