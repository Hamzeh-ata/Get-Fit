using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace get_fit.Migrations
{
    public partial class workoutFe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workoutDeatils",
                columns: table => new
                {
                    workoutId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    bodyPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reps = table.Column<int>(type: "int", nullable: false),
                    sets = table.Column<int>(type: "int", nullable: false),
                    videoLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workoutDeatils", x => x.workoutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workoutDeatils");
        }
    }
}
