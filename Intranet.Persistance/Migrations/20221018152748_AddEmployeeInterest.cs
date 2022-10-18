using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intranet.Persistance.Migrations
{
    public partial class AddEmployeeInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "EmployeeInterest",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInterest", x => new { x.InterestId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeInterest_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInterest_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInterest_EmployeeId",
                table: "EmployeeInterest",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInterest");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_UserId",
                table: "AspNetUsers");
        }
    }
}
