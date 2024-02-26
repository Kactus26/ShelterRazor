using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddImagesToAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "PetShelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "PetShelters");

            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Pets");
        }
    }
}
