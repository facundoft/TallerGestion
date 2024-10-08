using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TallerGestion.Models;

public partial class GestionContext : DbContext
{
    public GestionContext()
    {
    }

    public GestionContext(DbContextOptions<GestionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atenciones> Atenciones { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Gestioncalidad> Gestioncalidad { get; set; }

    public virtual DbSet<Oficinascomerciales> Oficinascomerciales { get; set; }

    public virtual DbSet<Operarios> Operarios { get; set; }

    public virtual DbSet<Puestosatencion> Puestosatencion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=gestion;user=root;password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atenciones>(entity =>
        {
            entity.HasKey(e => e.AtencionId).HasName("PRIMARY");

            entity.ToTable("atenciones");

            entity.HasIndex(e => e.ClienteId, "ClienteID");

            entity.HasIndex(e => e.OficinaId, "OficinaID");

            entity.HasIndex(e => e.OperarioId, "OperarioID");

            entity.HasIndex(e => e.PuestoId, "PuestoID");

            entity.Property(e => e.AtencionId).HasColumnName("AtencionID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.DescripcionTramite).HasMaxLength(100);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaHoraAtencion).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraFinalizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraLlegada).HasColumnType("datetime");
            entity.Property(e => e.OficinaId).HasColumnName("OficinaID");
            entity.Property(e => e.OperarioId).HasColumnName("OperarioID");
            entity.Property(e => e.PuestoId).HasColumnName("PuestoID");
            entity.Property(e => e.TramiteId).HasColumnName("TramiteID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Atenciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("atenciones_ibfk_1");

            entity.HasOne(d => d.Oficina).WithMany(p => p.Atenciones)
                .HasForeignKey(d => d.OficinaId)
                .HasConstraintName("atenciones_ibfk_2");

            entity.HasOne(d => d.Operario).WithMany(p => p.Atenciones)
                .HasForeignKey(d => d.OperarioId)
                .HasConstraintName("atenciones_ibfk_4");

            entity.HasOne(d => d.Puesto).WithMany(p => p.Atenciones)
                .HasForeignKey(d => d.PuestoId)
                .HasConstraintName("atenciones_ibfk_3");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.CedulaIdentidad, "CedulaIdentidad").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.CedulaIdentidad).HasMaxLength(20);
        });

        modelBuilder.Entity<Gestioncalidad>(entity =>
        {
            entity.HasKey(e => e.GestionCalidadId).HasName("PRIMARY");

            entity.ToTable("gestioncalidad");

            entity.HasIndex(e => e.OficinaId, "OficinaID");

            entity.Property(e => e.GestionCalidadId).HasColumnName("GestionCalidadID");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.OficinaId).HasColumnName("OficinaID");

            entity.HasOne(d => d.Oficina).WithMany(p => p.Gestioncalidad)
                .HasForeignKey(d => d.OficinaId)
                .HasConstraintName("gestioncalidad_ibfk_1");
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

        modelBuilder.Entity<Puestosatencion>(entity =>
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
