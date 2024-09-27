using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflis.Migrations
{
    /// <inheritdoc />
    public partial class actualicacionentidadserie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "AppSeries",
                newName: "trama");

            migrationBuilder.AddColumn<string>(
                name: "generos",
                table: "AppSeries",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "idioma",
                table: "AppSeries",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "generos",
                table: "AppSeries");

            migrationBuilder.DropColumn(
                name: "idioma",
                table: "AppSeries");

            migrationBuilder.RenameColumn(
                name: "trama",
                table: "AppSeries",
                newName: "tipo");
        }
    }
}
