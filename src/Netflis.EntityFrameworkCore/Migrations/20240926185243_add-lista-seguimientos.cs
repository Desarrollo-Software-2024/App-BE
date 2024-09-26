using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflis.Migrations
{
    /// <inheritdoc />
    public partial class addlistaseguimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaSeguimientoId",
                table: "AppSeries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppListaSeguimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppListaSeguimiento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSeries_ListaSeguimientoId",
                table: "AppSeries",
                column: "ListaSeguimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSeries_AppListaSeguimiento_ListaSeguimientoId",
                table: "AppSeries",
                column: "ListaSeguimientoId",
                principalTable: "AppListaSeguimiento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSeries_AppListaSeguimiento_ListaSeguimientoId",
                table: "AppSeries");

            migrationBuilder.DropTable(
                name: "AppListaSeguimiento");

            migrationBuilder.DropIndex(
                name: "IX_AppSeries_ListaSeguimientoId",
                table: "AppSeries");

            migrationBuilder.DropColumn(
                name: "ListaSeguimientoId",
                table: "AppSeries");
        }
    }
}
