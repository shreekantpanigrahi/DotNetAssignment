using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStudentManagementSystem.Models;

namespace OnlineStudentManagementSystem.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet Properties
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Primary Keys as Strings (GUIDs)
            modelBuilder.Entity<Student>().HasKey(s => s.Id); // Use string for Id
            modelBuilder.Entity<Course>().HasKey(c => c.Id);  // Use string for Id

            // Configure Enrollment Table with Composite Key
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId }); // Composite key using strings

            // Configure Relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId) // Foreign key is now a string
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete issues

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId) // Foreign key is now a string
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete issues
        }
    }
}