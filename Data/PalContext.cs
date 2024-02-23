using Microsoft.EntityFrameworkCore;
using PalModel;

namespace PalData;

public partial class PalContext(DbContextOptions<PalContext> options) : DbContext(options)
{
  public virtual DbSet<Pal> Pals { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Pal>(entity =>
    {
      entity.ToTable("Pal");

      // The Id property is the primary key
      entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");

      // The Name and Type properties are required
      entity.Property(e => e.Name).HasColumnName("name").IsRequired();
      entity.Property(e => e.Type).HasColumnName("type").IsRequired();
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
