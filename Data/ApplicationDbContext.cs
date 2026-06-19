using internat_bd.Models;
using Microsoft.EntityFrameworkCore;

namespace internat_bd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NewsItem> NewsItems { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<SchoolClass> SchoolClasses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<EventItem> EventItems { get; set; }

        public DbSet<Appeal> Appeals { get; set; }

        public DbSet<DocumentItem> DocumentItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SchoolClass>()
                .HasMany(schoolClass => schoolClass.Students)
                .WithOne(student => student.SchoolClass)
                .HasForeignKey(student => student.SchoolClassId);
        }
    }
}
