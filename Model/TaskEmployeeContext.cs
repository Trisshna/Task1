using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1;

namespace WebApplication1.Models
{
    public class TaskEmpContext : DbContext
    {
        #region Constructor
        public TaskEmpContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        public DbSet<Skills> Skills { get; set; }
        public DbSet<Emp> Employees { get; set; }
        public DbSet<SkillMap> Skillmaps { get; set; }

        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);

        }
        #endregion


        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Skills
            modelBuilder.Entity<Skills>().ToTable("Skills");
            modelBuilder.Entity<Skills>().Property(x => x.Name).IsRequired().HasMaxLength(30);
            #endregion

            #region Entity: Employee
            modelBuilder.Entity<Emp>().ToTable("Employees");
            modelBuilder.Entity<Emp>().Property(x => x.EmpName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Emp>().Property(x => x.Status).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Emp>().Property(x => x.Manager).HasMaxLength(30);
            modelBuilder.Entity<Emp>().Property(x => x.WFMmanager).HasMaxLength(30);
            modelBuilder.Entity<Emp>().Property(x => x.Email);
            modelBuilder.Entity<Emp>().Property(x => x.Lockstatus).HasMaxLength(30);
            modelBuilder.Entity<Emp>().Property(x => x.Experience).HasColumnType("decimal(5,0)");
            modelBuilder.Entity<Emp>().Property(x => x.ProfileID).HasColumnType("decimal(5,0)");
            #endregion

            #region Entity: SkillMap
            modelBuilder.Entity<SkillMap>().ToTable("SkillMap");
            modelBuilder.Entity<SkillMap>().HasKey(c => new { c.EmployeeID, c.SkillID });
            modelBuilder.Entity<SkillMap>().HasOne(a => a.employee).WithMany(b => b.skillmap).HasForeignKey(c => c.EmployeeID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SkillMap>().HasOne(a => a.skills).WithMany(b => b.skillmap).HasForeignKey(c => c.SkillID).OnDelete(DeleteBehavior.NoAction);
            #endregion



        }
       
        //public DbSet<WebApplication1.Employeeswithskills> Employeeswithskills { get; set; }
       
    }
}