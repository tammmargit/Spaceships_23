using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopTARge23.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAndCleaned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstate",
                table: "RealEstate");

            migrationBuilder.RenameTable(
                name: "RealEstate",
                newName: "RealEstates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RealEstates",
                table: "RealEstates");

            migrationBuilder.RenameTable(
                name: "RealEstates",
                newName: "RealEstate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealEstate",
                table: "RealEstate",
                column: "Id");
        }
    }
}
