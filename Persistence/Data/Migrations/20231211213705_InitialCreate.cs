using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
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
                name: "CategoriaPer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCategoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("idCategoriaPer", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.idEstado);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombrePais = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("idPais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoContacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("idTipoContacto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDireccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("idTipoDireccion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("idTipoPersona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTurno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idTurno", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreDepartamento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idDepartamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais",
                        column: x => x.IdPaisFk,
                        principalTable: "Pais",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_userRol_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreCiudad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamentoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idCiudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento",
                        column: x => x.IdDepartamentoFk,
                        principalTable: "Departamento",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Categoria",
                        column: x => x.IdCategoriaFk,
                        principalTable: "CategoriaPer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Ciudad",
                        column: x => x.IdCiudadFk,
                        principalTable: "Ciudad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_TipoPersona",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "TipoPersona",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactoPer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoContactoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idContactoPer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactoPer_Persona",
                        column: x => x.IdPersonaFk,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactoPer_TipoContacto",
                        column: x => x.IdTipoContactoFk,
                        principalTable: "TipoContacto",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dirPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoDireccionFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idDirPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dirPersona_Persona",
                        column: x => x.IdPersonaFk,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dirPersona_TipoDireccion",
                        column: x => x.IdTipoDireccionFk,
                        principalTable: "TipoDireccion",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    IdEstadoFk = table.Column<int>(type: "int", nullable: false),
                    fechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaFin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idContrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Cliente",
                        column: x => x.IdClienteFk,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contrato_Empleado",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contrato_Estado",
                        column: x => x.IdEstadoFk,
                        principalTable: "Estado",
                        principalColumn: "idEstado");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Programacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdContratoFk = table.Column<int>(type: "int", nullable: false),
                    IdTurnosFk = table.Column<int>(type: "int", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idProgramacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programacion_Contrato",
                        column: x => x.IdContratoFk,
                        principalTable: "Contrato",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Programacion_Empleado",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Programacion_Turno",
                        column: x => x.IdTurnosFk,
                        principalTable: "Turno",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdDepartamentoFk",
                table: "Ciudad",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PersonaId",
                table: "Cliente",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPer_IdPersonaFk",
                table: "ContactoPer",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPer_IdTipoContactoFk",
                table: "ContactoPer",
                column: "IdTipoContactoFk");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPer_descripcion",
                table: "ContactoPer",
                column: "descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdClienteFk",
                table: "Contrato",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdEmpleadoFk",
                table: "Contrato",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdEstadoFk",
                table: "Contrato",
                column: "IdEstadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPaisFk",
                table: "Departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_PersonaId",
                table: "Empleado",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdCategoriaFk",
                table: "Persona",
                column: "IdCategoriaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdCiudadFk",
                table: "Persona",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdPersona",
                table: "Persona",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdTipoPersonaFk",
                table: "Persona",
                column: "IdTipoPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Programacion_IdContratoFk",
                table: "Programacion",
                column: "IdContratoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Programacion_IdEmpleadoFk",
                table: "Programacion",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Programacion_IdTurnosFk",
                table: "Programacion",
                column: "IdTurnosFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_dirPersona_IdPersonaFk",
                table: "dirPersona",
                column: "IdPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_dirPersona_IdTipoDireccionFk",
                table: "dirPersona",
                column: "IdTipoDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolId",
                table: "userRol",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactoPer");

            migrationBuilder.DropTable(
                name: "Programacion");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "dirPersona");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "TipoContacto");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "TipoDireccion");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "CategoriaPer");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "TipoPersona");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
