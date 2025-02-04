using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tuincentrum.Models;

public partial class MvctuinCentrumContext : DbContext
{
    public MvctuinCentrumContext()
    {
    }

    public MvctuinCentrumContext(DbContextOptions<MvctuinCentrumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Leverancier> Leveranciers { get; set; }

    public virtual DbSet<Plant> Planten { get; set; }

    public virtual DbSet<Soort> Soorten { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MVCTuinCentrum;Trusted_Connection=True;");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Leverancier>(entity =>
        {
            entity.HasKey(e => e.LevNr).HasName("Leveranciers$PrimaryKey");

            entity.Property(e => e.Adres).HasMaxLength(30);
            entity.Property(e => e.Naam).HasMaxLength(30);
            entity.Property(e => e.PostNr).HasMaxLength(10);
            entity.Property(e => e.Woonplaats).HasMaxLength(30);
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.PlantNr).HasName("Planten$PrimaryKey");

            entity.Property(e => e.Kleur).HasMaxLength(10);
            entity.Property(e => e.Naam).HasMaxLength(30);
            entity.Property(e => e.VerkoopPrijs).HasColumnType("money");

            entity.HasOne(d => d.LevnrNavigation).WithMany(p => p.Planten)
                .HasForeignKey(d => d.Levnr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Planten$LeveranciersPlanten");

            entity.HasOne(d => d.SoortNrNavigation).WithMany(p => p.Planten)
                .HasForeignKey(d => d.SoortNr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Planten$SoortenPlanten");
        });

        modelBuilder.Entity<Soort>(entity =>
        {
            entity.HasKey(e => e.SoortNr).HasName("Soorten$PrimaryKey");

            entity.Property(e => e.Naam).HasMaxLength(10).HasColumnName("Soort");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
