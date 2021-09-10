using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.WebApp.Migrations
{
    public partial class SetUniqueKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schools",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Programs",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Persons",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_SchoolId_Name",
                table: "Programs",
                columns: new[] { "SchoolId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Link",
                table: "Persons",
                column: "Link",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PersonId_ProgramId",
                table: "Admissions",
                columns: new[] { "PersonId", "ProgramId" },
                unique: true);

            migrationBuilder.DropIndex(
                name: "IX_Admissions_PersonId",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Programs_SchoolId",
                table: "Programs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Programs_SchoolId",
                table: "Programs",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PersonId",
                table: "Admissions",
                column: "PersonId");

            migrationBuilder.DropIndex(
                name: "IX_Schools_Name",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Programs_SchoolId_Name",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Persons_Link",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_PersonId_ProgramId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schools",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
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
