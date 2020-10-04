using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAPI.Migrations
{
    public partial class Pertama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInfos",
                columns: table => new
                {
                    EmptId = table.Column<string>(nullable: false),
                    EmpName = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfos", x => x.EmptId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInfos");
        }
    }
}
