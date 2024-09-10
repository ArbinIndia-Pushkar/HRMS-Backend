using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttendaceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendanceRecordsJson",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttendanceRecordsJson",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
