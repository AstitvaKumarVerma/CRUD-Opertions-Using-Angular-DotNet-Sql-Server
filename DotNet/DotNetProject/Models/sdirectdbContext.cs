using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetProject.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AstitvaDepartment2904> AstitvaDepartment2904s { get; set; } = null!;
        public virtual DbSet<AstitvaDesignation2904> AstitvaDesignation2904s { get; set; } = null!;
        public virtual DbSet<AstitvaEmployees2904> AstitvaEmployees2904s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;UID=sdirectdb;PWD=sdirectdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AstitvaDepartment2904>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__AstitvaD__B2079BED0209C5E9");

                entity.ToTable("AstitvaDepartment2904");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AstitvaDesignation2904>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PK__AstitvaD__BABD60DE4369DF28");

                entity.ToTable("AstitvaDesignation2904");

                entity.Property(e => e.Designation)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AstitvaEmployees2904>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("PK__AstitvaE__8D663599BE257E03");

                entity.ToTable("AstitvaEmployees2904");

                entity.Property(e => e.BankName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BasicWages).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.Doj)
                    .HasColumnType("date")
                    .HasColumnName("DOJ");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([Prefix]+right('0000'+CONVERT([varchar](4),[EmployeeNumber]),(4)))", true);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Epf)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("EPF");

                entity.Property(e => e.Esi)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ESI");

                entity.Property(e => e.Esino).HasColumnName("ESINo");

                entity.Property(e => e.Hra)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("HRA");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Month)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NetSalary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Pfno)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("PFNo");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.TotalDeduction).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalEarning).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Uan)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("UAN");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AstitvaEmployees2904s)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AstitvaEm__Depar__7A9DCEEA");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.AstitvaEmployees2904s)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AstitvaEm__Desig__79A9AAB1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
