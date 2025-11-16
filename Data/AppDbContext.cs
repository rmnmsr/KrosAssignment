using Microsoft.EntityFrameworkCore;
using KrosAssignment.Models;

namespace KrosAssignment.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Division> Divisions => Set<Division>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure auto-generated primary keys
        modelBuilder.Entity<Company>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Division>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Project>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Department>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        // Company → Division
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Divisions)
            .WithOne(d => d.Company)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // Division → Project
        modelBuilder.Entity<Division>()
            .HasMany(d => d.Projects)
            .WithOne(p => p.Division)
            .HasForeignKey(p => p.DivisionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Project → Department
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Departments)
            .WithOne(d => d.Project)
            .HasForeignKey(d => d.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        // Department → Employee
        modelBuilder.Entity<Department>()
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Company → Leader (Employee)
        modelBuilder.Entity<Company>()
            .HasOne(c => c.Leader)
            .WithMany()
            .HasForeignKey(c => c.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Division → Leader (Employee)
        modelBuilder.Entity<Division>()
            .HasOne(d => d.Leader)
            .WithMany()
            .HasForeignKey(d => d.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Project → Leader (Employee)
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Leader)
            .WithMany()
            .HasForeignKey(p => p.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Department → Leader (Employee)
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Leader)
            .WithMany()
            .HasForeignKey(d => d.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Povinné polia + unikátne kódy
        modelBuilder.Entity<Company>()
            .Property(c => c.Code)
            .IsRequired();
        modelBuilder.Entity<Company>()
            .HasIndex(c => c.Code)
            .IsUnique();

        modelBuilder.Entity<Company>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Division>()
            .Property(d => d.Code)
            .IsRequired();
        modelBuilder.Entity<Division>()
            .HasIndex(d => d.Code)
            .IsUnique();

        modelBuilder.Entity<Division>()
            .Property(d => d.Name)
            .IsRequired();

        modelBuilder.Entity<Project>()
            .Property(p => p.Code)
            .IsRequired();
        modelBuilder.Entity<Project>()
            .HasIndex(p => p.Code)
            .IsUnique();

        modelBuilder.Entity<Project>()
            .Property(p => p.Name)
            .IsRequired();

        modelBuilder.Entity<Department>()
            .Property(d => d.Code)
            .IsRequired();
        modelBuilder.Entity<Department>()
            .HasIndex(d => d.Code)
            .IsUnique();

        modelBuilder.Entity<Department>()
            .Property(d => d.Name)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Title)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.FullName)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Phone)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Email)
            .IsRequired();
    }
}
