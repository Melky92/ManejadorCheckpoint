using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ManejadorCheckpoint.Models;

namespace ManejadorCheckpoint.Migrations
{
    [DbContext(typeof(checkpointContext))]
    partial class checkpointContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManejadorCheckpoint.Models.PuntoControl", b =>
                {
                    b.Property<int>("IdPuntoControl")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionDispositivo")
                        .HasColumnType("varchar(max)");

                    b.Property<double>("Latitud");

                    b.Property<double>("Longitud");

                    b.Property<string>("Referencia")
                        .HasColumnType("varchar(max)");

                    b.HasKey("IdPuntoControl")
                        .HasName("PK__PuntoCon__A2628BA2D1C566B4");

                    b.ToTable("PuntoControl");
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.RegistroPunto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Debug");

                    b.Property<DateTime>("FechaHora");

                    b.Property<int>("IdPunto");

                    b.Property<int>("IdVehiculo");

                    b.HasKey("Id");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("RegistroPunto");
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.Ruta", b =>
                {
                    b.Property<int>("IdRuta")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantidadDePuntos");

                    b.HasKey("IdRuta")
                        .HasName("PK__Ruta__887538FE37E11112");

                    b.ToTable("Ruta");
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.RutaPunto", b =>
                {
                    b.Property<int>("IdRuta");

                    b.Property<int>("IdPunto");

                    b.Property<int>("Numero");

                    b.HasKey("IdRuta", "IdPunto")
                        .HasName("PK_RutaPunto");

                    b.ToTable("RutaPunto");
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.TipoVehiculo", b =>
                {
                    b.Property<int>("IdTipoVehiculo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Etiqueta")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("IdRuta");

                    b.HasKey("IdTipoVehiculo")
                        .HasName("PK__TipoVehi__DC20741EC2CACF61");

                    b.HasIndex("IdRuta");

                    b.ToTable("TipoVehiculo");
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdTipoVehiculo");

                    b.Property<string>("IdentificadorBt")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("IdVehiculo")
                        .HasName("PK__Vehiculo__708612158BC1B875");

                    b.HasIndex("IdTipoVehiculo");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.RegistroPunto", b =>
                {
                    b.HasOne("ManejadorCheckpoint.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("IdVehiculo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.TipoVehiculo", b =>
                {
                    b.HasOne("ManejadorCheckpoint.Models.Ruta", "IdRutaNavigation")
                        .WithMany("TipoVehiculo")
                        .HasForeignKey("IdRuta")
                        .HasConstraintName("FK__TipoVehic__IdRut__38996AB5");
                });

            modelBuilder.Entity("ManejadorCheckpoint.Models.Vehiculo", b =>
                {
                    b.HasOne("ManejadorCheckpoint.Models.TipoVehiculo", "IdTipoVehiculoNavigation")
                        .WithMany("Vehiculo")
                        .HasForeignKey("IdTipoVehiculo")
                        .HasConstraintName("FK__Vehiculo__IdTipo__3B75D760");
                });
        }
    }
}
