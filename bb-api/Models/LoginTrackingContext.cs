using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bb_api.Models
{
    public partial class LoginTrackingContext : DbContext
    {
        public LoginTrackingContext()
        {
        }

        public LoginTrackingContext(DbContextOptions<LoginTrackingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblLoginsV2> TblLoginsV2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblLoginsV2>(entity =>
            {
                entity.ToTable("tblLoginsV2");

                entity.HasIndex(e => e.Username)
                    .HasName("IX_tblLoginsV2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dc)
                    .IsRequired()
                    .HasColumnName("dc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gw)
                    .IsRequired()
                    .HasColumnName("gw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logintype)
                    .IsRequired()
                    .HasColumnName("logintype")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Machine)
                    .IsRequired()
                    .HasColumnName("machine")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
