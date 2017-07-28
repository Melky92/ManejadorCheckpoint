using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManejadorCheckpoint.Migrations
{
    public partial class IdRegistroPuntoCheckpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_RegistroPunto",
            //    table: "RegistroPunto");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RegistroPunto",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistroPunto",
                table: "RegistroPunto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPunto_IdVehiculo",
                table: "RegistroPunto",
                column: "IdVehiculo");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_RegistroPunto_Vehiculo_IdVehiculo",
            //    table: "RegistroPunto",
            //    column: "IdVehiculo",
            //    principalTable: "Vehiculo",
            //    principalColumn: "IdVehiculo",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPunto_Vehiculo_IdVehiculo",
                table: "RegistroPunto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistroPunto",
                table: "RegistroPunto");

            migrationBuilder.DropIndex(
                name: "IX_RegistroPunto_IdVehiculo",
                table: "RegistroPunto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RegistroPunto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistroPunto",
                table: "RegistroPunto",
                columns: new[] { "IdVehiculo", "IdPunto" });
        }
    }
}
