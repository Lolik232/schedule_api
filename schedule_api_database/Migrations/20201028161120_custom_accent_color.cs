using Microsoft.EntityFrameworkCore.Migrations;

namespace schedule_api_database.Migrations
{
    public partial class custom_accent_color : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "custom_accent_color",
                table: "users_settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "custom_accent_color",
                table: "users_settings");
        }
    }
}
