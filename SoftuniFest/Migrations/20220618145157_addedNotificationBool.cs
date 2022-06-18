using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftuniFest.Migrations
{
    public partial class addedNotificationBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReceivingNotifications",
                schema: "App",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReceivingNotifications",
                schema: "App",
                table: "Users");
        }
    }
}
