using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.WebApp.Migrations
{
    public partial class ModifyProgramIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Programs",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_SchoolId_Department_Name",
                table: "Programs",
                columns: new[] { "SchoolId", "Department", "Name" },
                unique: true);

            migrationBuilder.DropIndex(
                name: "IX_Programs_SchoolId_Name",
                table: "Programs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Programs_SchoolId_Name",
                table: "Programs",
                columns: new[] { "SchoolId", "Name" },
                unique: true);

            migrationBuilder.DropIndex(
                name: "IX_Programs_SchoolId_Department_Name",
                table: "Programs");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Programs",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");            
        }
    }
}
