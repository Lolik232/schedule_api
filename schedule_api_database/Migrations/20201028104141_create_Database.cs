using Microsoft.EntityFrameworkCore.Migrations;

namespace schedule_api_database.Migrations
{
    public partial class create_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users_settings",
                columns: table => new
                {
                    settings_id = table.Column<string>(nullable: false),
                    gibbon_acc_id = table.Column<string>(nullable: false),
                    group_name = table.Column<string>(nullable: false),
                    group_link = table.Column<string>(nullable: false),
                    accent_color = table.Column<int>(nullable: false),
                    theme_state = table.Column<int>(nullable: false),
                    backdrop = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_settings", x => x.settings_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users_settings");
        }
    }
}
