using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgusEyesApi.Migrations
{
    public partial class ArgusKunden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KundenDaten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geburtsdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Alter = table.Column<int>(type: "int", nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hausnummer = table.Column<int>(type: "int", nullable: true),
                    Plz = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundenDaten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metadaten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Helligkeit = table.Column<int>(type: "int", nullable: false),
                    Kontrast = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadaten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PunktKoordinaten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunktKoordinaten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KundenImagesDaten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MetadatenId = table.Column<int>(type: "int", nullable: true),
                    PunktKoordinatenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundenImagesDaten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KundenImagesDaten_Metadaten_MetadatenId",
                        column: x => x.MetadatenId,
                        principalTable: "Metadaten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KundenImagesDaten_PunktKoordinaten_PunktKoordinatenId",
                        column: x => x.PunktKoordinatenId,
                        principalTable: "PunktKoordinaten",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "KundenDaten",
                columns: new[] { "Id", "Alter", "Geburtsdatum", "Hausnummer", "Nachname", "Plz", "Strasse", "Vorname" },
                values: new object[] { 1, 25, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Tamr", 12331, "hamburgerstr", "Omar" });

            migrationBuilder.InsertData(
                table: "KundenDaten",
                columns: new[] { "Id", "Alter", "Geburtsdatum", "Hausnummer", "Nachname", "Plz", "Strasse", "Vorname" },
                values: new object[] { 2, 25, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "HH", 12331, "hamburgerstr", "Rudi" });

            migrationBuilder.CreateIndex(
                name: "IX_KundenImagesDaten_MetadatenId",
                table: "KundenImagesDaten",
                column: "MetadatenId");

            migrationBuilder.CreateIndex(
                name: "IX_KundenImagesDaten_PunktKoordinatenId",
                table: "KundenImagesDaten",
                column: "PunktKoordinatenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KundenDaten");

            migrationBuilder.DropTable(
                name: "KundenImagesDaten");

            migrationBuilder.DropTable(
                name: "Metadaten");

            migrationBuilder.DropTable(
                name: "PunktKoordinaten");
        }
    }
}
