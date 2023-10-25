using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWeather.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Last_updated_epoch = table.Column<int>(type: "INTEGER", nullable: false),
                    Last_updated = table.Column<string>(type: "TEXT", nullable: false),
                    Temp_c = table.Column<float>(type: "REAL", nullable: false),
                    Temp_f = table.Column<float>(type: "REAL", nullable: false),
                    Is_day = table.Column<int>(type: "INTEGER", nullable: false),
                    Wind_mph = table.Column<float>(type: "REAL", nullable: false),
                    Wind_kph = table.Column<float>(type: "REAL", nullable: false),
                    Wind_degree = table.Column<int>(type: "INTEGER", nullable: false),
                    Wind_dir = table.Column<string>(type: "TEXT", nullable: false),
                    Pressure_mb = table.Column<float>(type: "REAL", nullable: false),
                    Pressure_in = table.Column<float>(type: "REAL", nullable: false),
                    Precip_mm = table.Column<float>(type: "REAL", nullable: false),
                    Precip_in = table.Column<float>(type: "REAL", nullable: false),
                    Humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    Cloud = table.Column<int>(type: "INTEGER", nullable: false),
                    Feelslike_c = table.Column<float>(type: "REAL", nullable: false),
                    Feelslike_f = table.Column<float>(type: "REAL", nullable: false),
                    Vis_km = table.Column<float>(type: "REAL", nullable: false),
                    Vis_miles = table.Column<float>(type: "REAL", nullable: false),
                    Uv = table.Column<float>(type: "REAL", nullable: false),
                    Gust_mph = table.Column<float>(type: "REAL", nullable: false),
                    Gust_kph = table.Column<float>(type: "REAL", nullable: false),
                    WeatherId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currents_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Lat = table.Column<float>(type: "REAL", nullable: false),
                    Lon = table.Column<float>(type: "REAL", nullable: false),
                    Tz_id = table.Column<string>(type: "TEXT", nullable: false),
                    Localtime_epoch = table.Column<int>(type: "INTEGER", nullable: false),
                    Localtime = table.Column<string>(type: "TEXT", nullable: false),
                    WeatherId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Currents_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "Currents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_CurrentId",
                table: "Conditions",
                column: "CurrentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currents_WeatherId",
                table: "Currents",
                column: "WeatherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_WeatherId",
                table: "Locations",
                column: "WeatherId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Currents");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
