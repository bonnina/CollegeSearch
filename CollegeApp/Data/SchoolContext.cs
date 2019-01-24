using System;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        //public DbSet<CollegeApp.Models.Student> Student { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
