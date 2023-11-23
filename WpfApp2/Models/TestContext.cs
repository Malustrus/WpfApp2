using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Charge> Charges { get; set; }

    public virtual DbSet<ChargeMachine> ChargeMachines { get; set; }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Test;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Charge>(entity =>
        {
            entity.ToTable("Charge");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Charge1)
                .HasMaxLength(50)
                .HasColumnName("Charge");

            entity.HasOne(d => d.Info).WithMany(p => p.Charges)
                .HasForeignKey(d => new { d.Fauf, d.Boat, d.Position })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Charge__37A5467C");
        });

        modelBuilder.Entity<ChargeMachine>(entity =>
        {
            entity.HasKey(e => new { e.ProcessId, e.Type, e.Position });

            entity.ToTable("ChargeMachine");

            entity.Property(e => e.ProcessId).HasColumnName("Process_ID");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Charge).HasMaxLength(50);

            entity.HasOne(d => d.P).WithMany(p => p.ChargeMachines)
                .HasForeignKey(d => new { d.ProcessId, d.Position })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChargeMachine__5070F446");
        });

        modelBuilder.Entity<Info>(entity =>
        {
            entity.HasKey(e => new { e.Fauf, e.Boat, e.Position }).HasName("PK__Info__925D3DD65DD0AEC8");

            entity.ToTable("Info");

            entity.Property(e => e.SerialNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.ToTable("Process");

            entity.Property(e => e.ProcessId).HasColumnName("Process_ID");
            entity.Property(e => e.DateFin).HasColumnType("datetime");
            entity.Property(e => e.Stand).HasMaxLength(50);
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => new { e.ProcessId, e.Position });

            entity.ToTable("Result");

            entity.Property(e => e.ProcessId).HasColumnName("Process_ID");

            entity.HasOne(d => d.Process).WithMany(p => p.Results)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Process_Result");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
