using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManejadorCheckpoint.Models
{
    public partial class checkpointContext : DbContext
    {
        public virtual DbSet<PuntoControl> PuntoControl { get; set; }
        public virtual DbSet<RegistroPunto> RegistroPunto { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<RutaPunto> RutaPunto { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public checkpointContext(DbContextOptions<checkpointContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PuntoControl>(entity =>
            {
                entity.HasKey(e => e.IdPuntoControl)
                    .HasName("PK__PuntoCon__A2628BA2D1C566B4");

                entity.Property(e => e.DescripcionDispositivo).HasColumnType("varchar(max)");

                entity.Property(e => e.Referencia).HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.HasKey(e => e.IdRuta)
                    .HasName("PK__Ruta__887538FE37E11112");
            });

            modelBuilder.Entity<RutaPunto>(entity =>
            {
                entity.HasKey(e => new { e.IdRuta, e.IdPunto })
                    .HasName("PK_RutaPunto");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehiculo)
                    .HasName("PK__TipoVehi__DC20741EC2CACF61");

                entity.Property(e => e.Etiqueta)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.HasOne(d => d.IdRutaNavigation)
                    .WithMany(p => p.TipoVehiculo)
                    .HasForeignKey(d => d.IdRuta)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__TipoVehic__IdRut__38996AB5");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__708612158BC1B875");

                entity.Property(e => e.IdentificadorBt).HasColumnType("varchar(max)");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Vehiculo__IdTipo__3B75D760");
            });
        }
    }
}