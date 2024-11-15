using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflis.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalApiStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTotalApiMonitoringStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAccesses = table.Column<int>(type: "int", nullable: false),
                    AverageResponseTime = table.Column<double>(type: "float", nullable: false),
                    TotalErrors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTotalApiMonitoringStats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTotalApiMonitoringStats");
        }
    }
}
