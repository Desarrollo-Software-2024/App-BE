using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflis.Migrations
{
    /// <inheritdoc />
    public partial class addserieentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    fechaLanzamiento = table.Column<DateOnly>(type: "date", nullable: false),
                    directores = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    escritores = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    elenco = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    portada = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    paisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calificacionImdb = table.Column<int>(type: "int", nullable: false),
                    duracion = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSeries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSeries");
        }
    }
}
