using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLSV_API.Models;

public partial class SinhVienContext : DbContext
{
    public SinhVienContext()
    {
    }

    public SinhVienContext(DbContextOptions<SinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MDDBSE18;database=SinhVien;Trusted_Connection=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.IdFaculty).HasName("PK__Faculty__0D72F2BF2D3FAD87");

            entity.ToTable("Faculty");

            entity.Property(e => e.IdFaculty).ValueGeneratedNever();
            entity.Property(e => e.NameFaculty).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudent).HasName("PK__Student__61B35104F07766B8");

            entity.ToTable("Student");

            entity.Property(e => e.IdStudent).ValueGeneratedNever();
            entity.Property(e => e.BirthdayStudent).HasColumnType("date");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.NameStudent).HasMaxLength(50);

            entity.HasOne(d => d.IdFacultyNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__IdFacul__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
