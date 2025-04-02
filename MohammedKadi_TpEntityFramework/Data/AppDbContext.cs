using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MohammedKadi_TpEntityFramework.Entities;

namespace MohammedKadi_TpEntityFramework.Data
{
    public class AppDbContext : DbContext {

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // configuration de la connection string
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            // recperation de la connection string
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder
                .UseLazyLoadingProxies() // utilisation de lazy loading
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // utilisation tpc aproche
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();

            // configuration des relation entre les entités
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Subject)
                .WithMany()
                .HasForeignKey(t => t.SubjectId);

            modelBuilder.Entity<Student>()
            .HasIndex(s => s.StudentNumber)
            .IsUnique();

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany()
                .HasForeignKey(c => c.TeacherId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Class)
                .WithMany()
                .HasForeignKey(e => e.ClassId);


            // Relation entre Enrollment et Student (désactiver la cascade)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);



            // insertion 2 student données avant la creation du schema
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1,FirstName = "Mohammed", LastName = "Kadi", StudentNumber = 1234525 },
                new Student { Id= 2, FirstName = "Abdo", LastName = "mokhtar", StudentNumber = 1254235 }
            );

        }


    }
}
