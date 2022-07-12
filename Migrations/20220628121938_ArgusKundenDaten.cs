using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArgusEyesApi.Migrations
{
    public partial class ArgusKundenDaten : Migration
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

            migrationBuilder.InsertData(
                table: "KundenDaten",
                columns: new[] { "Id", "Alter", "Geburtsdatum", "Hausnummer", "Nachname", "Plz", "Strasse", "Vorname" },
                values: new object[] { 1, 25, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Tamr", 12331, "hamburgerstr", "Omar" });

            migrationBuilder.InsertData(
                table: "KundenDaten",
                columns: new[] { "Id", "Alter", "Geburtsdatum", "Hausnummer", "Nachname", "Plz", "Strasse", "Vorname" },
                values: new object[] { 2, 25, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "HH", 12331, "hamburgerstr", "Rudi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KundenDaten");
        }
    }
}
