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

    }
}
