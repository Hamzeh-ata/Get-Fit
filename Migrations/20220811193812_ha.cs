using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace get_fit.Migrations
{
    public partial class ha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_workoutSummary",
                table: "workoutSummary");

            migrationBuilder.AlterColumn<string>(
                name: "workoutGoal",
                table: "workoutSummary",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "workoutSummary",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workoutSummary",
                table: "workoutSummary",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_workoutSummary",
                table: "workoutSummary");

            migrationBuilder.DropColumn(
                name: "id",
                table: "workoutSummary");

            migrationBuilder.AlterColumn<string>(
                name: "workoutGoal",
                table: "workoutSummary",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workoutSummary",
                table: "workoutSummary",
                column: "workoutGoal");
        }
    }
}
