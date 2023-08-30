using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "long", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_TipoPersonas_Id",
                        column: x => x.Id,
                        principalTable: "TipoPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cliente_TipoPersonas_IdTipoPersonaFk",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "TipoPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPersonFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empleado_TipoPersonas_Id",
                        column: x => x.Id,
                        principalTable: "TipoPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_TipoPersonas_IdTipoPersonFk",
                        column: x => x.IdTipoPersonFk,
                        principalTable: "TipoPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdTipoPersonaFk",
                table: "cliente",
                column: "IdTipoPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdTipoPersonFk",
                table: "empleado",
                column: "IdTipoPersonFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "TipoPersonas");
        }
    }
}
