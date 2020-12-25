using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Admin" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@gmail.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = Gender.Male,
                DepartmentId = 1,
                Photo = "images/john.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary.smith@gmail.com",
                DateOfBirth = new DateTime(1993, 1, 1),
                Gender = Gender.Female,
                DepartmentId = 2,
                Photo = "images/mary.jpg"
            });
        }
    }
}
