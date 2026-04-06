using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_management_sys.Migrations
{
    /// <inheritdoc />
    public partial class AddUserYoBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Bookings");
        }
    }
}
