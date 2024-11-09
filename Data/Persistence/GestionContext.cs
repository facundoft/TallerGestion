using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TallerGestion.Models;

namespace TallerGestion.Data.Persistence;

public partial class GestionContext : DbContext
{
    public GestionContext()
    {
    }

    public GestionContext(DbContextOptions<GestionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Oficinascomerciales> Oficinascomerciales { get; set; }

    public virtual DbSet<Operarios> Operarios { get; set; }

    public virtual DbSet<PuestoAtencion> Puestosatencion { get; set; }

    public virtual DbSet<Tramite> Tramite { get; set; }

    public virtual DbSet<Atenciones> Atenciones { get; set; }

    public virtual DbSet<CantAtencionesTramite> CantAtencionesTramite { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.CedulaIdentidad, "CedulaIdentidad").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.CedulaIdentidad).HasMaxLength(20);
        });

        modelBuilder.Entity<Oficinascomerciales>(entity =>
        {
            entity.HasKey(e => e.OficinaId).HasName("PRIMARY");

            entity.ToTable("oficinascomerciales");

            entity.Property(e => e.OficinaId).HasColumnName("OficinaID");
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Operarios>(entity =>
        {
            entity.HasKey(e => e.OperarioId).HasName("PRIMARY");

            entity.ToTable("operarios");

            entity.HasIndex(e => e.OficinaId, "OficinaID");

            entity.Property(e => e.OperarioId).HasColumnName("OperarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.OficinaId).HasColumnName("OficinaID");

            entity.HasOne(d => d.Oficina).WithMany(p => p.Operarios)
                .HasForeignKey(d => d.OficinaId)
                .HasConstraintName("operarios_ibfk_1");
        });

        modelBuilder.Entity<PuestoAtencion>(entity =>
        {
            entity.HasKey(e => e.PuestoId).HasName("PRIMARY");

            entity.ToTable("puestosatencion");

            entity.HasIndex(e => e.OficinaId, "OficinaID");

            entity.Property(e => e.PuestoId).HasColumnName("PuestoID");
            entity.Property(e => e.OficinaId).HasColumnName("OficinaID");

            entity.HasOne(d => d.Oficina).WithMany(p => p.Puestosatencion)
                .HasForeignKey(d => d.OficinaId)
                .HasConstraintName("puestosatencion_ibfk_1");
        });

        modelBuilder.Entity<Tramite>(entity =>
        {
            entity.HasKey(e => e.TramiteId).HasName("PRIMARY");

            entity.ToTable("tramite");

            entity.Property(e => e.TramiteId).HasColumnName("TramiteID");
            entity.Property(e => e.DescripcionTramite)
                .IsRequired()
                .HasMaxLength(100);
        });


        modelBuilder.Entity<Atenciones>(entity =>
        {
            entity.HasKey(e => e.AtencionId).HasName("PRIMARY"); // Define AtencionId como clave primaria

            entity.ToTable("atenciones");

            entity.Property(e => e.AtencionId)
                .HasColumnName("AtencionID")
                .ValueGeneratedOnAdd();  // Configura que AtencionId sea autogenerado

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.OficinaId).HasColumnName("OficinaID");
            entity.Property(e => e.PuestoId).HasColumnName("PuestoID");
            entity.Property(e => e.OperarioId).HasColumnName("OperarioID");
            entity.Property(e => e.TramiteId).HasColumnName("TramiteID");

            entity.Property(e => e.FechaHoraLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraAtencion).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraFinalizacion).HasColumnType("datetime");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.SegundaLlamado).HasColumnType("tinyint");
        });

        modelBuilder.Entity<CantAtencionesTramite>(entity =>
        {

            entity.HasKey(e => e.TramiteID).HasName("PRIMARY");
            entity.ToTable("CantAtencionesTramite");
            entity.Property(e => e.TramiteID).HasColumnName("TramiteID");
            entity.Property(e => e.CantAtenciones).HasColumnName("CantAtenciones");
            entity.Property(e => e.DescripcionTramite).HasColumnName("DescripcionTramite");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
