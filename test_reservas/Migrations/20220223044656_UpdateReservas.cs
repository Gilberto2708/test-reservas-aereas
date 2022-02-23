using Microsoft.EntityFrameworkCore.Migrations;

namespace test_reservas.Migrations
{
    public partial class UpdateReservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Precio",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Pasajero",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Tipo_Pasajero",
                table: "Reserva");
        }
    }
}
