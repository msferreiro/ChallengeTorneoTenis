using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorneoTenis.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: false),
                    Habilidad = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    TorneoId = table.Column<int>(type: "int", nullable: false),
                    TiempoReaccion = table.Column<int>(type: "int", nullable: true),
                    Fuerza = table.Column<int>(type: "int", nullable: true),
                    VelocidadDesplazamiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    CantidadJugadores = table.Column<int>(type: "int", nullable: false),
                    GanadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Torneo_Jugador_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Jugador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_TorneoId",
                table: "Jugador",
                column: "TorneoId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneo_GanadorId",
                table: "Torneo",
                column: "GanadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugador_Torneo_TorneoId",
                table: "Jugador",
                column: "TorneoId",
                principalTable: "Torneo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugador_Torneo_TorneoId",
                table: "Jugador");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "Jugador");
        }
    }
}
