using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsBreak.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumberPlate",
                columns: table => new
                {
                    NumberPlateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MapFriendlyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Registration = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberPlate", x => x.NumberPlateID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberPlate");
        }
    }
}
