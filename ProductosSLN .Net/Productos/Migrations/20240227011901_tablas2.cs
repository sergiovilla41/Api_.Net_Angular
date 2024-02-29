using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Productos.Migrations
{
    /// <inheritdoc />
    public partial class tablas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Imagen_ImagenId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Imagen");

            migrationBuilder.RenameColumn(
                name: "ImagenId",
                table: "Productos",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Productos",
                newName: "Imagen");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_ImagenId",
                table: "Productos",
                newName: "IX_Productos_CategoriaId");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorias = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categoria_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categoria_CategoriaId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Productos",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Productos",
                newName: "ImagenId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                newName: "IX_Productos_ImagenId");

            migrationBuilder.CreateTable(
                name: "Imagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagen", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Imagen_ImagenId",
                table: "Productos",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
