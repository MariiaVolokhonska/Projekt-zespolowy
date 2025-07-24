using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRLogic.Migrations
{
    /// <inheritdoc />
    public partial class Services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Services",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "PointPrice",
                table: "Services",
                type: "int",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "ImageUrl",
               table: "Services");

            migrationBuilder.DropColumn(
               name: "PointPrice",
               table: "Services");
        }
    }
}
