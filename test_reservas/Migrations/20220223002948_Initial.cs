using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test_reservas.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aeropuerto_Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario_Salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aeropuerto_Llegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario_Llegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aerolinea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero_Vuelo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");
        }
    }
}
