using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HydraulicFix.Migrations
{
    /// <inheritdoc />
    public partial class Arreglando_Modelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagen",
                table: "Configuraciones",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Configuraciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 2,
                column: "NombreEstado",
                value: "En Proceso");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 3,
                column: "NombreEstado",
                value: "Completado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Configuraciones");

            migrationBuilder.AlterColumn<byte>(
                name: "Imagen",
                table: "Configuraciones",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 2,
                column: "NombreEstado",
                value: "EnProceso");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 3,
                column: "NombreEstado",
                value: "Terminado");
        }
    }
}
