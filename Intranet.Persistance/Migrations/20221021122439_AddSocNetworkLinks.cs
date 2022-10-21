using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intranet.Persistance.Migrations
{
    public partial class AddSocNetworkLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileFacebook",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileInstagram",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileLinkedin",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileFacebook",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileInstagram",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileLinkedin",
                table: "AspNetUsers");
        }
    }
}
