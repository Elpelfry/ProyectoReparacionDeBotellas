using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HydraulicFix.Migrations
{
    /// <inheritdoc />
    public partial class agregandoAtributos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Cantidad", "CategoriaId", "Codigo", "Descuento", "EsDisponible", "ITBIS", "Nombre", "Precio", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 4, 0, "1111", 6.0, false, 4, "Sello mecánico de cartucho", 500.0, 0 },
                    { 2, 6, 0, "1111", 6.0, false, 4, "Limpiador hidráulio", 200.0, 0 },
                    { 3, 3, 0, "1111", 6.0, false, 4, "Sello de pistón", 240.0, 0 },
                    { 4, 5, 0, "1111", 6.0, false, 4, "Collarín de fijación para ejes", 450.0, 0 },
                    { 5, 6, 0, "1111", 6.0, false, 4, "Retén de eje de goma", 200.0, 0 },
                    { 6, 3, 0, "1111", 6.0, false, 4, "Lubricante para rodamientos", 240.0, 0 },
                    { 7, 5, 0, "1111", 6.0, false, 4, "Filtro de aire", 450.0, 0 },
                    { 8, 6, 0, "1111", 6.0, false, 4, "Retén de doble labio", 200.0, 0 },
                    { 9, 3, 0, "1111", 6.0, false, 4, "Sello de vástago para cilindros neumáticos", 240.0, 0 },
                    { 10, 5, 0, "1111", 6.0, false, 4, "Sello de fibra de cerámica.", 450.0, 0 },
                    { 11, 2, 0, "1111", 6.0, false, 4, "Sello de válvula de globo", 100.0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 11);

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
        }
    }
}
