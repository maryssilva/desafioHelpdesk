using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketEvent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ticketId",
                table: "TicketEvents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvents_ticketId",
                table: "TicketEvents",
                column: "ticketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEvents_Tickets_ticketId",
                table: "TicketEvents",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "ticketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketEvents_Tickets_ticketId",
                table: "TicketEvents");

            migrationBuilder.DropIndex(
                name: "IX_TicketEvents_ticketId",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "ticketId",
                table: "TicketEvents");
        }
    }
}
