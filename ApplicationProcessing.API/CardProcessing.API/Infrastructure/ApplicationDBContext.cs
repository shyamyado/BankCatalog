using ApplicationProcessing.API.Infrastructure.Entityconfiguration;
using ApplicationProcessing.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationProcessing.API.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        private const string ConnectionString = "Server=SHYAMASUS\\SQLEXPRESS;Initial Catalog=ApplicationDB;Integrated Security=true;TrustServerCertificate=True;";


        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ApplicationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationStatusEntityTypeConfiguration());
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, p => p.MigrationsAssembly("ApplicationProcessing.API"));
        }


    }
}
