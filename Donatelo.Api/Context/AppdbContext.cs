using Donatelo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Donatelo.Api.Context
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {
            
        }
        public DbSet<UsuarioDto> UsuarioDTO { get; set; }
        public DbSet<DonacionDto> DonacionDTO { get; set; }
        public DbSet<SedeDto> SedeDTO { get; set; }
        public DbSet<PublicacionDto> PublicacionDtos { get; set; }
        public DbSet<SolicitudesDonacionDto> solicitudesDonacionDtos { get; set; }
        public DbSet<NotificacionesDto> notificacionesDtos { get; set; }
        public DbSet<RolTypeDto> rolTypeDtos { get; set; }
        public DbSet<EstadoPublicacionDto> estadoPublicacionDtos { get; set; }
        public DbSet<EstadoDonacionDto> estadoDonacionDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonacionDto>(entity =>
            {
                entity.ToTable("Donaciones");
                entity.HasKey(p => p.DonacionId).HasName("PK_DonacionId");

                entity.Property(p => p.DonacionId)

                .HasColumnName("DonacionId")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<UsuarioDto>(entity =>
            {

                entity.ToTable("usuarios");
                entity.HasKey(p => p.UsuarioId).HasName("PK_UsuarioId");

                entity.Property(p => p.UsuarioId)

                .HasColumnName("UsuarioId")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<SedeDto>(entity =>
            {
                entity.ToTable("Sedes");
                entity.HasKey(p => p.SedeId).HasName("PK_SedeId");

                entity.Property(p => p.SedeId)

                .HasColumnName("SedeId")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<PublicacionDto>(entity =>
            {
                entity.ToTable("Publicaciones");
                entity.HasKey(p => p.PublicacionId).HasName("PK_PublicacionId");

                entity.Property(p => p.PublicacionId)

                .HasColumnName("PublicacionId")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<SolicitudesDonacionDto>(entity =>
            {
                entity.ToTable("SolicitudesDonacion");
                entity.HasKey(p => p.solicitudId).HasName("PK_SolicitudId");

                entity.Property(p => p.solicitudId)

                .HasColumnName("SolicitudId")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<NotificacionesDto>(entity =>
            {
                entity.ToTable("Notificaciones");
                entity.HasKey(p => p.Notificacionid).HasName("PK_NotificacionId");

                entity.Property(p => p.Notificacionid)

                .HasColumnName("NotificacionId")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<RolTypeDto>(entity =>
            {
                entity.ToTable("roltype");
                entity.HasKey(p => p.Rolid).HasName("PK_RolId");

                entity.Property(p => p.Rolid)

                .HasColumnName("RolId")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<EstadoDonacionDto>(entity =>
            {
                entity.ToTable("EstadoDonacion");
                entity.HasKey(p => p.estadoid).HasName("FK_EstadoID");

                entity.Property(p => p.estadoid)

                .HasColumnName("EstadoID")

                .HasColumnType("int").ValueGeneratedNever();
            });

            modelBuilder.Entity<EstadoPublicacionDto>(entity =>
            {
                entity.ToTable("EstadoPublicacion");
                entity.HasKey(p => p.estadoid).HasName("FK_EstadoID");

                entity.Property(p => p.estadoid)

                .HasColumnName("EstadoID")

                .HasColumnType("int").ValueGeneratedNever();
            });
        }
    }
}
