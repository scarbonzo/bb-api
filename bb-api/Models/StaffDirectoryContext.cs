using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bb_api.Models
{
    public partial class StaffDirectoryContext : DbContext
    {
        public StaffDirectoryContext()
        {
        }

        public StaffDirectoryContext(DbContextOptions<StaffDirectoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adusers> Adusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adusers>(entity =>
            {
                entity.ToTable("ADUsers");

                entity.HasIndex(e => e.TermOfEmploymentId)
                    .IsUnique()
                    .HasFilter("([TermOfEmploymentId] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deletiondate)
                    .HasColumnName("deletiondate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Displayname)
                    .IsRequired()
                    .HasColumnName("displayname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Expirable).HasColumnName("expirable");

                entity.Property(e => e.Extension)
                    .HasColumnName("extension")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Groups)
                    .IsRequired()
                    .HasColumnName("groups")
                    .IsUnicode(false);

                entity.Property(e => e.Lastlogin)
                    .HasColumnName("lastlogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("lastupdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .IsUnicode(false);

                entity.Property(e => e.Office)
                    .HasColumnName("office")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ou)
                    .IsRequired()
                    .HasColumnName("ou")
                    .IsUnicode(false);

                entity.Property(e => e.Passwordlastset)
                    .HasColumnName("passwordlastset")
                    .HasColumnType("datetime");

                entity.Property(e => e.Program)
                    .HasColumnName("program")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
