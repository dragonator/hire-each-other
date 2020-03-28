using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HireEachOther.Data.Migrations
{
    public partial class AddedCommentModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    TargetId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdComments_Ads_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    TargetId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_Users_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdComments_TargetId",
                table: "AdComments",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_AdComments_UserId",
                table: "AdComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_TargetId",
                table: "UserComments",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserId",
                table: "UserComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdComments");

            migrationBuilder.DropTable(
                name: "UserComments");
        }
    }
}
