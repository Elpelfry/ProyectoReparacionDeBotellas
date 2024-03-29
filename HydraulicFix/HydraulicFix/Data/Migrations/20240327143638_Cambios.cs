using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HydraulicFix.Migrations
{
    /// <inheritdoc />
    public partial class Cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TecnicoId",
                table: "Reparaciones",
                newName: "Tecnico");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Reparaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Reparaciones");

            migrationBuilder.RenameColumn(
                name: "Tecnico",
                table: "Reparaciones",
                newName: "TecnicoId");
        }
    }
}
