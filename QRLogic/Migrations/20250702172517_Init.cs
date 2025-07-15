using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRLogic.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GroupProject");

<<<<<<< HEAD:QRLogic/Migrations/20250702172517_Init.cs
            migrationBuilder.CreateTable(
                name: "QrCodeScans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodeScans", x => x.Id);
                });
=======
            
>>>>>>> 0afc2b2c95cdb2eebd045aa901fd72611bd7f72f:QRLogic/Migrations/20250701222724_Users.cs

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "GroupProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LasttName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<< HEAD:QRLogic/Migrations/20250702172517_Init.cs
                name: "QrCodeScans");

            migrationBuilder.DropTable(
=======
>>>>>>> 0afc2b2c95cdb2eebd045aa901fd72611bd7f72f:QRLogic/Migrations/20250701222724_Users.cs
                name: "Users",
                schema: "GroupProject");
        }
    }
}
