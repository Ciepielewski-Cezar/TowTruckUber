using Microsoft.EntityFrameworkCore.Migrations;

namespace TowTruckUberAPI.Migrations
{
    public partial class UpdatedMapGridToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MapGrids_UserLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserLocationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MapGrids",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MapGrids_UserId",
                table: "MapGrids",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MapGrids_AspNetUsers_UserId",
                table: "MapGrids",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapGrids_AspNetUsers_UserId",
                table: "MapGrids");

            migrationBuilder.DropIndex(
                name: "IX_MapGrids_UserId",
                table: "MapGrids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MapGrids");

            migrationBuilder.AddColumn<int>(
                name: "UserLocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserLocationId",
                table: "AspNetUsers",
                column: "UserLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MapGrids_UserLocationId",
                table: "AspNetUsers",
                column: "UserLocationId",
                principalTable: "MapGrids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
