using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intranet.Persistance.Migrations
{
    public partial class AddEmployeeInterestKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmployeeInterest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeInterest");
        }
    }
}
