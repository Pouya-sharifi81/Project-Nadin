using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nadin_DAL.Migrations
{
    public partial class tree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_userProfiles_UserProfilesUserProfileId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserProfilesUserProfileId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserProfilesUserProfileId",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserProfileId",
                table: "Product",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_userProfiles_UserProfileId",
                table: "Product",
                column: "UserProfileId",
                principalTable: "userProfiles",
                principalColumn: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_userProfiles_UserProfileId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserProfileId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfilesUserProfileId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserProfilesUserProfileId",
                table: "Product",
                column: "UserProfilesUserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_userProfiles_UserProfilesUserProfileId",
                table: "Product",
                column: "UserProfilesUserProfileId",
                principalTable: "userProfiles",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
