using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTicketEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actionType",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "description",
                table: "TicketEvents");

            migrationBuilder.RenameColumn(
                name: "eventUpdatedAt",
                table: "TicketEvents",
                newName: "eventChangedAt");

            migrationBuilder.AddColumn<int>(
                name: "agentFk",
                table: "TicketEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "agentId",
                table: "TicketEvents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketEvents_agentId",
                table: "TicketEvents",
                column: "agentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEvents_Agents_agentId",
                table: "TicketEvents",
                column: "agentId",
                principalTable: "Agents",
                principalColumn: "agentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketEvents_Agents_agentId",
                table: "TicketEvents");

            migrationBuilder.DropIndex(
                name: "IX_TicketEvents_agentId",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "agentFk",
                table: "TicketEvents");

            migrationBuilder.DropColumn(
                name: "agentId",
                table: "TicketEvents");

            migrationBuilder.RenameColumn(
                name: "eventChangedAt",
                table: "TicketEvents",
                newName: "eventUpdatedAt");

            migrationBuilder.AddColumn<string>(
                name: "actionType",
                table: "TicketEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "TicketEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
