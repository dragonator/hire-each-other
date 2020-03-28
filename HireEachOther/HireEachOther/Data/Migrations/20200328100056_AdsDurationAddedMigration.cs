using Microsoft.EntityFrameworkCore.Migrations;

namespace HireEachOther.Data.Migrations
{
    public partial class AdsDurationAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeopleNeeded",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "PeopleNeeded",
                table: "Ads");
        }
    }
}
