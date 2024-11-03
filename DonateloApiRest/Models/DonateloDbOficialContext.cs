using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DonateloApiRest.Models;

public partial class DonateloDbOficialContext : DbContext
{
    public DonateloDbOficialContext()
    {
    }

    public DonateloDbOficialContext(DbContextOptions<DonateloDbOficialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Donacione> Donaciones { get; set; }

    public virtual DbSet<EstadoDonacion> EstadoDonacions { get; set; }

    public virtual DbSet<EstadoPublicacion> EstadoPublicacions { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Publicacione> Publicaciones { get; set; }

    public virtual DbSet<Roltype> Roltypes { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<SolicitudesDonacion> SolicitudesDonacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-6EOFKQM\\ig;Database=DonateloDbOficial;Trust Server Certificate=True;Integrated Security=True;Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donacione>(entity =>
        {
            entity.HasKey(e => e.DonacionId).HasName("PK__Donacion__9F5DEE879C312C19");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoEntrega)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donaciones_EstadoDonacion");

            entity.HasOne(d => d.Publicacion).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.PublicacionId)
                .HasConstraintName("FK__Donacione__Publi__48CFD27E");

            entity.HasOne(d => d.Sede).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.SedeId)
                .HasConstraintName("FK__Donacione__SedeI__49C3F6B7");

            entity.HasOne(d => d.UsuarioIdBeneficiadoNavigation).WithMany(p => p.DonacioneUsuarioIdBeneficiadoNavigations)
                .HasForeignKey(d => d.UsuarioIdBeneficiado)
                .HasConstraintName("FK__Donacione__Usuar__47DBAE45");

            entity.HasOne(d => d.UsuarioIdDonanteNavigation).WithMany(p => p.DonacioneUsuarioIdDonanteNavigations)
                .HasForeignKey(d => d.UsuarioIdDonante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Donacione__Usuar__46E78A0C");
        });

        modelBuilder.Entity<EstadoDonacion>(entity =>
        {
            entity.HasKey(e => e.EstadoId);

            entity.ToTable("EstadoDonacion");

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<EstadoPublicacion>(entity =>
        {
            entity.HasKey(e => e.EstadoId);

            entity.ToTable("EstadoPublicacion");

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.NotificacionId).HasName("PK__Notifica__BCC12024E35ED855");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Leido).HasDefaultValue(false);
            entity.Property(e => e.Mensaje).HasColumnType("text");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__Usuar__4F7CD00D");
        });

        modelBuilder.Entity<Publicacione>(entity =>
        {
            entity.HasKey(e => e.PublicacionId).HasName("PK__Publicac__10DF158AC3109F13");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicaciones_EstadoPublicacion");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Publicaci__Usuar__412EB0B6");
        });

        modelBuilder.Entity<Roltype>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__roltype__F92302F1C6C4785E");

            entity.ToTable("roltype");

            entity.HasIndex(e => e.Nombre, "UQ__roltype__75E3EFCFDD0EAA1C").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.SedeId).HasName("PK__Sedes__FD76DFDB1651BA86");

            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SolicitudesDonacion>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DC76799107D");

            entity.ToTable("SolicitudesDonacion");

            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Beneficiado).WithMany(p => p.SolicitudesDonacions)
                .HasForeignKey(d => d.BeneficiadoId)
                .HasConstraintName("FK__Solicitud__Benef__7B5B524B");

            entity.HasOne(d => d.Donacion).WithMany(p => p.SolicitudesDonacions)
                .HasForeignKey(d => d.DonacionId)
                .HasConstraintName("FK__Solicitud__Donac__7A672E12");

            entity.HasOne(d => d.Estado).WithMany(p => p.SolicitudesDonacions)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Solicitud__Estad__7C4F7684");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__usuarios__2B3DE7B803B35E89");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "UQ__usuarios__60695A19C4C24314").IsUnique();

            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("FK__usuarios__Rol__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
