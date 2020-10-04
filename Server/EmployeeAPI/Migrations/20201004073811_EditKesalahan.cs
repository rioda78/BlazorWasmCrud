using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAPI.Migrations
{
    public partial class EditKesalahan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInfos");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeInfos",
                columns: table => new
                {
                    EmptId = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    Designation = table.Column<string>(type: "TEXT", nullable: true),
                    EmpName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfos", x => x.EmptId);
                });
        }
    }
}
