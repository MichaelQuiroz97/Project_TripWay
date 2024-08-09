using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BETripWay.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cdestino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cdestino__3214EC07886B42BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTitular = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Expiracion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cvc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MetodoPa__3214EC071BBAAFCF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPais = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pais__B501E185364AF088", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promocio__3214EC079C00B309", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaIda = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaRegreso = table.Column<DateTime>(type: "datetime", nullable: false),
                    CiudadOrigen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Viaje = table.Column<int>(type: "int", nullable: false),
                    Clase = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reserva__3214EC0702DFC0E4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CedulaUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    PaisResidencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__C0B559BC7CA1F68E", x => x.CedulaUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ciudad__D4D3CCB0BFDBC68B", x => x.IdCiudad);
                    table.ForeignKey(
                        name: "FK__Ciudad__PaisId__6754599E",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "PaisId");
                });

            migrationBuilder.CreateTable(
                name: "Pasajero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pasajero__3214EC076178DB44", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Pasajero__Reserv__7B5B524B",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ComentarioTexto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CedulaUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comentar__3214EC07146B4C51", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Comentari__Cedul__0B91BA14",
                        column: x => x.CedulaUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CedulaUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Equipaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipaje__3214EC07953104C1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Equipaje__Cedula__08B54D69",
                        column: x => x.CedulaUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CedulaUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ciudad = table.Column<int>(type: "int", nullable: false),
                    Transporte = table.Column<bool>(type: "bit", nullable: false),
                    CiudadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aeropuer__3214EC0735712352", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Aeropuert__Ciuda__10566F31",
                        column: x => x.Ciudad,
                        principalTable: "Ciudad",
                        principalColumn: "IdCiudad");
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCiudad = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nhabitaciones = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hotel__653BCCC4CF2CC5AA", x => x.IdHotel);
                    table.ForeignKey(
                        name: "FK__Hotel__IdCiudad__02084FDA",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudad",
                        principalColumn: "IdCiudad");
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NVuelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NAeropuerto = table.Column<int>(type: "int", nullable: false),
                    FPartida = table.Column<DateTime>(type: "datetime", nullable: false),
                    Corigen = table.Column<int>(type: "int", nullable: true),
                    CDestino = table.Column<int>(type: "int", nullable: true),
                    Nocturno = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vuelo__3214EC07BF48FBF9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Vuelo__CDestino__32AB8735",
                        column: x => x.CDestino,
                        principalTable: "Cdestino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Vuelo__Corigen__31B762FC",
                        column: x => x.Corigen,
                        principalTable: "Ciudad",
                        principalColumn: "IdCiudad");
                    table.ForeignKey(
                        name: "FK__Vuelo__NAeropuer__339FAB6E",
                        column: x => x.NAeropuerto,
                        principalTable: "Aeropuerto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    IdHabitaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHotel = table.Column<int>(type: "int", nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    TipoHabitacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CedulaUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Habitaci__2CD071588BE05988", x => x.IdHabitaciones);
                    table.ForeignKey(
                        name: "FK__Habitacio__Cedul__05D8E0BE",
                        column: x => x.CedulaUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CedulaUsuario");
                    table.ForeignKey(
                        name: "FK__Habitacio__IdHot__04E4BC85",
                        column: x => x.IdHotel,
                        principalTable: "Hotel",
                        principalColumn: "IdHotel");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aeropuerto_Ciudad",
                table: "Aeropuerto",
                column: "Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_PaisId",
                table: "Ciudad",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_CedulaUsuario",
                table: "Comentario",
                column: "CedulaUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Equipaje_CedulaUsuario",
                table: "Equipaje",
                column: "CedulaUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_CedulaUsuario",
                table: "Habitacion",
                column: "CedulaUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_IdHotel",
                table: "Habitacion",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_IdCiudad",
                table: "Hotel",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Pasajero_ReservaId",
                table: "Pasajero",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_CDestino",
                table: "Vuelo",
                column: "CDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_Corigen",
                table: "Vuelo",
                column: "Corigen");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_NAeropuerto",
                table: "Vuelo",
                column: "NAeropuerto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Equipaje");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Pasajero");

            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "Vuelo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Cdestino");

            migrationBuilder.DropTable(
                name: "Aeropuerto");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
