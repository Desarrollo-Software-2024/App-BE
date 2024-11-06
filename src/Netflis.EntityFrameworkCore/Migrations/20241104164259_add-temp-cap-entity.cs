using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflis.Migrations
{
    /// <inheritdoc />
    public partial class addtempcapentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "paisOrigen",
                table: "AppSeries",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "totalTemporadas",
                table: "AppSeries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppTemporadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    fechaLanzamiento = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    serieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTemporadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTemporadas_AppSeries_serieId",
                        column: x => x.serieId,
                        principalTable: "AppSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppCapitulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroEpisodio = table.Column<int>(type: "int", nullable: false),
                    fechaEstreno = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    directores = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    escritores = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    duracion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    resumen = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    temporadaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCapitulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCapitulos_AppTemporadas_temporadaID",
                        column: x => x.temporadaID,
                        principalTable: "AppTemporadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCapitulos_temporadaID",
                table: "AppCapitulos",
                column: "temporadaID");

            migrationBuilder.CreateIndex(
                name: "IX_AppTemporadas_serieId",
                table: "AppTemporadas",
                column: "serieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCapitulos");

            migrationBuilder.DropTable(
                name: "AppTemporadas");

            migrationBuilder.DropColumn(
                name: "totalTemporadas",
                table: "AppSeries");

            migrationBuilder.AlterColumn<string>(
                name: "paisOrigen",
                table: "AppSeries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
