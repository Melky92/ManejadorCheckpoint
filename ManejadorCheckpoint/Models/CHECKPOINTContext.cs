using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManejadorCheckpoint.Models
{
    public partial class CHECKPOINTContext : DbContext
    {
        public virtual DbSet<PuntoControl> PuntoControl { get; set; }
        public virtual DbSet<RegistroPunto> RegistroPunto { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<RutaPunto> RutaPunto { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public CHECKPOINTContext(DbContextOptions<CHECKPOINTContext> options)
            : base(options)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Data Source=USER;Initial Catalog=CHECKPOINT;Integrated Security=True;Persist Security Info=True;User ID=Dell");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PuntoControl>(entity =>
            {
                entity.HasKey(e => e.IdPuntoControl)
                    .HasName("PK__PuntoCon__A2628BA255E5CFCF");

                entity.Property(e => e.DescripcionDispositivo).HasColumnType("varchar(max)");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.PuntoControl)
                    .HasForeignKey(d => d.IdUbicacion)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__PuntoCont__IdUbi__403A8C7D");
            });

            modelBuilder.Entity<RegistroPunto>(entity =>
            {
                entity.HasKey(e => new { e.IdVehiculo, e.IdPunto })
                    .HasName("PK_RegistroPunto");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.HasKey(e => e.IdRuta)
                    .HasName("PK__Ruta__887538FEAF77599B");
            });

            modelBuilder.Entity<RutaPunto>(entity =>
            {
                entity.HasKey(e => new { e.IdRuta, e.IdPunto })
                    .HasName("PK_RutaPunto");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehiculo)
                    .HasName("PK__TipoVehi__DC20741EC53D426F");

                entity.Property(e => e.Etiqueta)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.HasOne(d => d.IdRutaNavigation)
                    .WithMany(p => p.TipoVehiculo)
                    .HasForeignKey(d => d.IdRuta)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__TipoVehic__IdRut__38996AB5");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.IdUbicacion)
                    .HasName("PK__Ubicacio__778CAB1D52DA2120");

                entity.Property(e => e.Referencia).HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__7086121584A5AFC1");

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