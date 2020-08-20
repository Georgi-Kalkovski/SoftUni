using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniORM.App.Data.Entities
{
    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        { 
        }

        public DbSet<Employee> Employees { get; }

        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<EmployeesProject> employeesProjects { get; }
    }
}
