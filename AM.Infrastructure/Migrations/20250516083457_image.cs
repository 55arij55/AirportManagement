using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_PassengerFK",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "Pilot",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                columns: new[] { "PassengerFK", "FlightFK" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightFK",
                table: "Ticket",
                column: "FlightFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_FlightFK",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Pilot",
                table: "Flights");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                columns: new[] { "FlightFK", "PassengerFK" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerFK",
                table: "Ticket",
                column: "PassengerFK");
        }
    }
}
