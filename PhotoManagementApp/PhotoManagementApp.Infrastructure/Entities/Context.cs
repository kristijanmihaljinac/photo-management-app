using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PhotoManagementApp.Infrastructure.Entities
{
    public partial class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PackageRestriction> PackageRestrictions { get; set; } = null!;
        public virtual DbSet<PackageRestrictionValue> PackageRestrictionValues { get; set; } = null!;
        public virtual DbSet<RegistryType> RegistryTypes { get; set; } = null!;
        public virtual DbSet<SystemSetting> SystemSettings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=PhotoManagementDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasPrecision(0);

                entity.Property(e => e.DateLastModified).HasPrecision(0);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.PackageUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_AppUser");

                entity.HasOne(d => d.UserLastModified)
                    .WithMany(p => p.PackageUserLastModifieds)
                    .HasForeignKey(d => d.UserLastModifiedId)
                    .HasConstraintName("FK_Package_AppUser1");
            });

            modelBuilder.Entity<PackageRestriction>(entity =>
            {
                entity.ToTable("PackageRestriction");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.DataType).HasMaxLength(255);

                entity.Property(e => e.DateCreated).HasPrecision(0);

                entity.Property(e => e.DefaultValue).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.PackageRestrictionUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackageRestriction_AppUser");

                entity.HasOne(d => d.UserLastModified)
                    .WithMany(p => p.PackageRestrictionUserLastModifieds)
                    .HasForeignKey(d => d.UserLastModifiedId)
                    .HasConstraintName("FK_PackageRestriction_AppUser1");
            });

            modelBuilder.Entity<PackageRestrictionValue>(entity =>
            {
                entity.ToTable("PackageRestrictionValue");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value).HasMaxLength(255);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageRestrictionValues)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackageRestrictionValue_Package");

                entity.HasOne(d => d.PackageRestriction)
                    .WithMany(p => p.PackageRestrictionValues)
                    .HasForeignKey(d => d.PackageRestrictionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackageRestrictionValue_PackageRestriction");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.PackageRestrictionValueUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackageRestrictionValue_AppUser");

                entity.HasOne(d => d.UserLastModified)
                    .WithMany(p => p.PackageRestrictionValueUserLastModifieds)
                    .HasForeignKey(d => d.UserLastModifiedId)
                    .HasConstraintName("FK_PackageRestrictionValue_AppUser1");
            });

            modelBuilder.Entity<RegistryType>(entity =>
            {
                entity.ToTable("RegistryType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemSetting>(entity =>
            {
                entity.ToTable("SystemSetting");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
