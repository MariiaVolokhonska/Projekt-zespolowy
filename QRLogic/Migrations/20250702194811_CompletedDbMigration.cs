using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRLogic.Migrations
{
    /// <inheritdoc />
    public partial class CompletedDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "QrCodeScans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QrCodeScans");
        }
    }
}
