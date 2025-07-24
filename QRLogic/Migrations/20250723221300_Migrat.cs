using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRLogic.Migrations
{
    /// <inheritdoc />
    public partial class Migrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiredPoints",
                table: "Coupons");

            migrationBuilder.AddColumn<string>(
                name: "QrCode",
                table: "Coupons",
                type: "nvarchar(450)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequiredPoints",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "QrCode",
                table: "Coupons");
        }
    }
}
