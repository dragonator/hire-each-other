using Microsoft.EntityFrameworkCore.Migrations;

namespace HireEachOther.Data.Migrations
{
    public partial class AdsAddressAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Ads",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Ads");
        }
    }
}
