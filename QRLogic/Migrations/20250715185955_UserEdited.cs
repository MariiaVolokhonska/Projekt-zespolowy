using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRLogic.Migrations
{
    /// <inheritdoc />
    public partial class UserEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LasttName",
                schema: "GroupProject",
                table: "Users",
                newName: "LastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "GroupProject",
                table: "Users",
                newName: "LasttName");
        }
    }
}
