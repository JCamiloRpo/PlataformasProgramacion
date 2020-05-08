using Microsoft.EntityFrameworkCore.Migrations;

namespace UVirtual.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escenario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    NotaMeta = table.Column<int>(nullable: false),
                    EmocionMeta = table.Column<int>(nullable: false),
                    TiempoMeta = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escenario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    NotaAcomulada = table.Column<int>(nullable: false),
                    EmocionAcomulada = table.Column<int>(nullable: false),
                    TiempoAcomulado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Situacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    Inicio = table.Column<bool>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    EscenarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol_Escenario_EscenarioID",
                        column: x => x.EscenarioID,
                        principalTable: "Escenario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    NotaCambio = table.Column<int>(nullable: false),
                    EmocionCambio = table.Column<int>(nullable: false),
                    TiempoCambio = table.Column<int>(nullable: false),
                    SituacionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuesta_Situacion_SituacionID",
                        column: x => x.SituacionID,
                        principalTable: "Situacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    RolID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personaje_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonajeID = table.Column<int>(nullable: false),
                    SituacionID = table.Column<int>(nullable: false),
                    RespuestaID = table.Column<int>(nullable: false),
                    Respuesta2ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Personaje_PersonajeID",
                        column: x => x.PersonajeID,
                        principalTable: "Personaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Respuesta_Respuesta2ID",
                        column: x => x.Respuesta2ID,
                        principalTable: "Respuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Respuesta_RespuestaID",
                        column: x => x.RespuestaID,
                        principalTable: "Respuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Situacion_SituacionID",
                        column: x => x.SituacionID,
                        principalTable: "Situacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_RolID",
                table: "Personaje",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_SituacionID",
                table: "Respuesta",
                column: "SituacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_EscenarioID",
                table: "Rol",
                column: "EscenarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_PersonajeID",
                table: "Tarjeta",
                column: "PersonajeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_Respuesta2ID",
                table: "Tarjeta",
                column: "Respuesta2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_RespuestaID",
                table: "Tarjeta",
                column: "RespuestaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_SituacionID",
                table: "Tarjeta",
                column: "SituacionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Situacion");

            migrationBuilder.DropTable(
                name: "Escenario");
        }
    }
}
