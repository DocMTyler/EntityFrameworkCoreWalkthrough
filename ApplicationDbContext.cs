using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Building> Building { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<SectionRoster> SectionRoster { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<GradeItem> GradeItem { get; set; }
        public DbSet<GradeType> GradeType { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
        }

        public ApplicationDbContext() : base()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public static ApplicationDbContext GetDBContext()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", false, true);

            var config = builder.Build();
            var connectionString = config["ConnectionStrings:SimpleSchool"];

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
