using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.WebApp.Migrations
{
    public partial class ModifySchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Schools",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Programs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Programs");
        }
    }
}
