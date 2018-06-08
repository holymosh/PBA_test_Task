using Common;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure
{
    public class DepartmentContext :DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> departmentContext) :base(departmentContext)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var departmentBuilder = modelBuilder.Entity<Department>();
            departmentBuilder.ToTable("Department");
            departmentBuilder.HasKey(department => department.Id);
            departmentBuilder.Property(department => department.Title).HasColumnName("Title");

            base.OnModelCreating(modelBuilder);
        }

    }
}
