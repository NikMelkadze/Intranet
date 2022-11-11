using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intranet.Persistance.Migrations
{
    public partial class AddUserSexProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1a92efd-30e7-4a62-9102-b5851735dc85", "AQAAAAEAACcQAAAAEI+LImZnlTZSevj/oJbM6+It9nqTNnCQ4ZruzLS5bEiK7FiOEtCR7azRGaGlKPB0LA==", "4ba2a4fa-6ae5-4fa0-a41d-f68df0cc9475" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31b5d0ba-9b8c-4e25-a23f-0e1c7f48b8a9", "AQAAAAEAACcQAAAAEByplUUzmMGgzKprNzMgW0xivjwIKoRgaLaCHd2VvRzABOM1CR+q6V6z7BuzBiOp+g==", "088a5690-59e5-4d89-8b1b-9fb481135086" });
        }
    }
}
