using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Models;

public partial class StaffsContext : DbContext
{
    public StaffsContext()
    {
    }

    public StaffsContext(DbContextOptions<StaffsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public static async Task CreateDatabase() {
    using (var dbcontext = new StaffsContext())
    {
        String databasename = dbcontext.Database.GetDbConnection().Database;// mydata

        Console.WriteLine("Tạo " + databasename);

        bool result = await dbcontext.Database.EnsureCreatedAsync();
        string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
        Console.WriteLine($"CSDL {databasename} : {resultstring}");
    }
}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost; database=staffs; uid=root; password=0834023573Dat@@");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.DepartmentId, "DepartmentID");

            entity.HasIndex(e => e.GenderId, "GenderID");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.DateofBirth).HasColumnType("date");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.Gender).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PRIMARY");

            entity.ToTable("gender");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderDescription).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
