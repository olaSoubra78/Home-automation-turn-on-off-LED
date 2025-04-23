using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EspTest3.Models;

public partial class DbAb2616EsptestContext : DbContext
{
    public DbAb2616EsptestContext()
    {
    }

    public DbAb2616EsptestContext(DbContextOptions<DbAb2616EsptestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAction> TblActions { get; set; }

    public virtual DbSet<TblLed> TblLeds { get; set; }

    public virtual DbSet<TblLedAction> TblLedActions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL1003.site4now.net;Initial Catalog=db_ab2616_esptest;PersistSecurityInfo=True;User ID=db_ab2616_esptest_admin;Password=Abood1234;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAction>(entity =>
        {
            entity.HasKey(e => e.ActionId);

            entity.ToTable("TblAction");

            entity.Property(e => e.ActionId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(3);
        });

        modelBuilder.Entity<TblLed>(entity =>
        {
            entity.HasKey(e => e.LedId);

            entity.ToTable("TblLed");

            entity.Property(e => e.LedColour).HasMaxLength(10);
        });

        modelBuilder.Entity<TblLedAction>(entity =>
        {
            entity.HasKey(e => e.LedActionId);

            entity.ToTable("TblLedAction");

            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Action).WithMany(p => p.TblLedActions)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblLedAction_TblAction");

            entity.HasOne(d => d.Led).WithMany(p => p.TblLedActions)
                .HasForeignKey(d => d.LedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblLedAction_TblLed");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
