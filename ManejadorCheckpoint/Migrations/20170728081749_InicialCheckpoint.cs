using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManejadorCheckpoint.Migrations
{
    public partial class InicialCheckpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PuntoControl",
                columns: table => new
                {
                    IdPuntoControl = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionDispositivo = table.Column<string>(type: "varchar(max)", nullable: true),
                    Latitud = table.Column<double>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Referencia = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PuntoCon__A2628BA2D1C566B4", x => x.IdPuntoControl);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPunto",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(nullable: false),
                    IdPunto = table.Column<int>(nullable: false),
                    FechaHora = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPunto", x => new { x.IdVehiculo, x.IdPunto });
                });

            migrationBuilder.CreateTable(
                name: "Ruta",
                columns: table => new
                {
                    IdRuta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadDePuntos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ruta__887538FE37E11112", x => x.IdRuta);
                });

            migrationBuilder.CreateTable(
                name: "RutaPunto",
                columns: table => new
                {
                    IdRuta = table.Column<int>(nullable: false),
                    IdPunto = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutaPunto", x => new { x.IdRuta, x.IdPunto });
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Etiqueta = table.Column<string>(type: "varchar(max)", nullable: false),
                    IdRuta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoVehi__DC20741EC2CACF61", x => x.IdTipoVehiculo);
                    table.ForeignKey(
                        name: "FK__TipoVehic__IdRut__38996AB5",
                        column: x => x.IdRuta,
                        principalTable: "Ruta",
                        principalColumn: "IdRuta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTipoVehiculo = table.Column<int>(nullable: false),
                    IdentificadorBt = table.Column<string>(type: "varchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehiculo__708612158BC1B875", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK__Vehiculo__IdTipo__3B75D760",
                        column: x => x.IdTipoVehiculo,
                        principalTable: "TipoVehiculo",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoVehiculo_IdRuta",
                table: "TipoVehiculo",
                column: "IdRuta");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdTipoVehiculo",
                table: "Vehiculo",
                column: "IdTipoVehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuntoControl");

            migrationBuilder.DropTable(
                name: "RegistroPunto");

            migrationBuilder.DropTable(
                name: "RutaPunto");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "TipoVehiculo");

            migrationBuilder.DropTable(
                name: "Ruta");
        }
    }
}
