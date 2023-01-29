using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace task2.Models
{
    public class companydbcontext:DbContext
    {
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<department> Departments { get; set; }
        public virtual DbSet<dependent> Dependents { get; set; }

        public virtual DbSet<location> DLocations { get; set; }
        public virtual DbSet<project> Projects { get; set; }

        public virtual DbSet<workon> WorkOns { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-GFUDS8G\\SS17;Initial Catalog=NEWCOMPANY;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<workon>().HasKey("ESSN", "Pnum");
            modelBuilder.Entity<dependent>().HasKey("name", "EmployeeSSN");
            modelBuilder.Entity<location>().HasKey("Dlocation", "Dnum");
            modelBuilder.Entity<employee>().HasOne("Department").WithMany("Employees");
            modelBuilder.Entity<employee>().HasOne("Departmentt").WithOne("Employee");
        }
    }
}
