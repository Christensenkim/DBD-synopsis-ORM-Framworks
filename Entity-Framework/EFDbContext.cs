using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class EFDbContext : DbContext
    {

        //string connectionString = @"Server=DESKTOP-NDVLOHO;Database=EntityFramework;Trusted_Connection=True;";
        string connectionString = @"Server=LECHAMPDK;Database=EntityFramework;Trusted_Connection=True;";


        public EFDbContext()
        {
        }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<SkillDescription> SkillDescription { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
