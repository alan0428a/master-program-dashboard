using Microsoft.EntityFrameworkCore;
using Master.Domain;

namespace Master.DataAccess
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Program>()
                .HasIndex(x => new { x.SchoolId, x.Department, x.Name})
                .IsUnique();

            modelBuilder.Entity<Person>()
                .HasIndex(x => x.Link)
                .IsUnique();

            modelBuilder.Entity<Admission>()
                .HasIndex(x => new { x.PersonId, x.ProgramId })
                .IsUnique();
        }

    }
}
