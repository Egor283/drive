using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Driver.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Licen> Licens { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=test;uid=root;pwd=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.23-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("driver");

            entity.HasIndex(e => e.PhotoId, "photoId_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Guid)
                .HasMaxLength(45)
                .HasColumnName("guid");
            entity.Property(e => e.Lastname)
                .HasMaxLength(45)
                .HasColumnName("lastname");
            entity.Property(e => e.LivingAddres)
                .HasMaxLength(45)
                .HasColumnName("livingAddres");
            entity.Property(e => e.LivingCity)
                .HasMaxLength(45)
                .HasColumnName("livingCity");
            entity.Property(e => e.MobPhone)
                .HasMaxLength(45)
                .HasColumnName("mobPhone");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PasportNumber)
                .HasMaxLength(45)
                .HasColumnName("pasportNumber");
            entity.Property(e => e.PasportSerial)
                .HasMaxLength(45)
                .HasColumnName("pasportSerial");
            entity.Property(e => e.PhotoId)
                .HasColumnType("int(11)")
                .HasColumnName("photoId");
            entity.Property(e => e.RegistrationAddres)
                .HasMaxLength(45)
                .HasColumnName("registrationAddres");
            entity.Property(e => e.RegistrationCity)
                .HasMaxLength(45)
                .HasColumnName("registrationCity");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
            entity.Property(e => e.WorkPlace)
                .HasMaxLength(45)
                .HasColumnName("workPlace");
            entity.Property(e => e.WorkRole)
                .HasMaxLength(45)
                .HasColumnName("workRole");

            entity.HasOne(d => d.Photo).WithOne(p => p.Driver)
                .HasForeignKey<Driver>(d => d.PhotoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("photo");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("history");

            entity.HasIndex(e => e.IdLicens, "histori_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdLicens)
                .HasColumnType("int(11)")
                .HasColumnName("id_licens");
            entity.Property(e => e.NewStatus)
                .HasMaxLength(45)
                .HasColumnName("new_status");
            entity.Property(e => e.OldStatus)
                .HasMaxLength(45)
                .HasColumnName("old_status");

            entity.HasOne(d => d.IdLicensNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdLicens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("histori");
        });

        modelBuilder.Entity<Licen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("licens");

            entity.HasIndex(e => e.DriverId, "driv_idx");

            entity.HasIndex(e => e.StatusId, "stat_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Catergory)
                .HasMaxLength(45)
                .HasColumnName("catergory");
            entity.Property(e => e.DriverId)
                .HasColumnType("int(11)")
                .HasColumnName("driver_id");
            entity.Property(e => e.ExpireDate)
                .HasColumnType("datetime")
                .HasColumnName("expire date");
            entity.Property(e => e.LicenceDate)
                .HasColumnType("datetime")
                .HasColumnName("licence date");
            entity.Property(e => e.LicenceSeries)
                .HasMaxLength(45)
                .HasColumnName("licence series");
            entity.Property(e => e.StatusId)
                .HasColumnType("int(11)")
                .HasColumnName("status_id");

            entity.HasOne(d => d.Driver).WithMany(p => p.Licens)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("driv");

            entity.HasOne(d => d.Status).WithMany(p => p.Licens)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stat");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("photo");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Photo1)
                .HasColumnType("blob")
                .HasColumnName("photo");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.StatusDes)
                .HasMaxLength(45)
                .HasColumnName("status_des");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
