using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4321Afanasev.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicDegree",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicDegree",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Teachers");
        }
    }
}
