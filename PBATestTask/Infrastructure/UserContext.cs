using System;
using Common;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> contextOptions) :base(contextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.ToTable("User");
            userBuilder.HasKey(user => user.Id).HasName("Id");
            userBuilder.Property(user => user.Username).HasColumnName("Username");
            userBuilder.Property(user => user.DepartmentId).HasColumnName("DepartmentId"); // в тестовом задании это будет property так как департамент и пользователь лежат в разных бд
            base.OnModelCreating(modelBuilder);
        }

    }
}
