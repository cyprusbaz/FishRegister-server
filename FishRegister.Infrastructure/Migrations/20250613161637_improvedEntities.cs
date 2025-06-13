using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishRegister.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class improvedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishPosts_Fishes_FishId",
                table: "FishPosts");

            migrationBuilder.DropIndex(
                name: "IX_FishPosts_FishId",
                table: "FishPosts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "FishPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FishPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "FishPosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FishPosts");

            migrationBuilder.CreateIndex(
                name: "IX_FishPosts_FishId",
                table: "FishPosts",
                column: "FishId");

            migrationBuilder.AddForeignKey(
                name: "FK_FishPosts_Fishes_FishId",
                table: "FishPosts",
                column: "FishId",
                principalTable: "Fishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
