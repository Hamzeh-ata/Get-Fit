using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace get_fit.Migrations
{
    public partial class workoutSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workoutSummary",
                columns: table => new
                {
                    workoutGoal = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    workoutTimeNeed = table.Column<int>(type: "int", nullable: false),
                    workoutDaysneed = table.Column<int>(type: "int", nullable: false),
                    workoutTotalSets = table.Column<int>(type: "int", nullable: false),
                    workoutLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workoutSummary", x => x.workoutGoal);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workoutSummary");
        }
    }
}
