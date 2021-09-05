using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TripEssential.Data.Entities
{
    public partial class TripEssentialContext : DbContext
    {
        public TripEssentialContext()
        {
        }

        public TripEssentialContext(DbContextOptions<TripEssentialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Knapsack> Knapsacks { get; set; }
        public virtual DbSet<TripItem> TripItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(FirmamentUtilities.Utilities.DatabaseHelper.ConnectionString);
                optionsBuilder.UseLazyLoadingProxies(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Knapsack>(entity =>
            {
                entity.ToTable("Knapsack");

                entity.Property(e => e.KnapsackId)
                    .HasColumnName("KnapsackID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DeletionDate).HasColumnType("datetime");

                entity.Property(e => e.TripItemId).HasColumnName("TripItemID");

                entity.HasOne(d => d.TripItem)
                    .WithMany(p => p.Knapsacks)
                    .HasForeignKey(d => d.TripItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Knapsack_TripItem");
            });

            modelBuilder.Entity<TripItem>(entity =>
            {
                entity.ToTable("TripItem");

                entity.Property(e => e.TripItemId)
                    .HasColumnName("TripItemID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WeightInGrams).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
