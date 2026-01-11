using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpdeskAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Agents_agentFk",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "agentFk",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Agents_agentFk",
                table: "Tickets",
                column: "agentFk",
                principalTable: "Agents",
                principalColumn: "agentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Agents_agentFk",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "agentFk",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Agents_agentFk",
                table: "Tickets",
                column: "agentFk",
                principalTable: "Agents",
                principalColumn: "agentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
