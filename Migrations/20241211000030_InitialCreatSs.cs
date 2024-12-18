using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GranjaGraphQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatSs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porcinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Identificacion = table.Column<string>(type: "text", nullable: false),
                    Raza = table.Column<string>(type: "text", nullable: true),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porcinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porcinos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alimentaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PorcinoId = table.Column<int>(type: "integer", nullable: false),
                    Detalles = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimentaciones_Porcinos_PorcinoId",
                        column: x => x.PorcinoId,
                        principalTable: "Porcinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellidos", "Cedula", "Direccion", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "1234567890", "Calle Falsa 123", "Juan", "555-1234" },
                    { 2, "Gómez", "0987654321", "Calle Verdadera 456", "Ana", "555-5678" }
                });

            migrationBuilder.InsertData(
                table: "Porcinos",
                columns: new[] { "Id", "ClienteId", "Edad", "Identificacion", "Peso", "Raza" },
                values: new object[,]
                {
                    { 1, 1, 2, "P001", 120.5f, "Landrace" },
                    { 2, 2, 3, "P002", 150.2f, "Duroc" }
                });

            migrationBuilder.InsertData(
                table: "Alimentaciones",
                columns: new[] { "Id", "Detalles", "PorcinoId" },
                values: new object[,]
                {
                    { 1, "Alimentación balanceada con proteínas", 1 },
                    { 2, "Alimentación con maíz y soja", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentaciones_PorcinoId",
                table: "Alimentaciones",
                column: "PorcinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Porcinos_ClienteId",
                table: "Porcinos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentaciones");

            migrationBuilder.DropTable(
                name: "Porcinos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
