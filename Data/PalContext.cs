using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PalModel;

namespace PalData;

public partial class PalContext : DbContext
{
    public PalContext(DbContextOptions<PalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pal> Pals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pal>(entity =>
        {
            entity.ToTable("Pal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
