using Microsoft.EntityFrameworkCore.Migrations;

namespace TowTruckUberAPI.Migrations
{
    public partial class AddedMapGridToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
