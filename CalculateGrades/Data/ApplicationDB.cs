
using CalculateGrades.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculateGrades.Data;
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) :base(options)
        {
        }

        
       // public DbSet<Marks> marks { get; set; }
        public DbSet<Years> years { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }

