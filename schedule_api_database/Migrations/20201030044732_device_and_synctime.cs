using Microsoft.EntityFrameworkCore.Migrations;

namespace schedule_api_database.Migrations
{
    public partial class device_and_synctime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "device",
                table: "users_settings",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "last_sync_unix_time",
                table: "users_settings",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "device",
                table: "users_settings");

            migrationBuilder.DropColumn(
                name: "last_sync_unix_time",
                table: "users_settings");
        }
    }
}
