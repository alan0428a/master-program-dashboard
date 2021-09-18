using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.WebApp.Migrations
{
    public partial class ModifyPersonGre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gre",
                table: "Persons",
                newName: "GreVerbal");

            migrationBuilder.AddColumn<int>(
                name: "GreQuant",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GreQuant",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "GreVerbal",
                table: "Persons",
                newName: "Gre");
        }
    }
}
