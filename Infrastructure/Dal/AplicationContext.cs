using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Dal
{
    public class AplicationContext:DbContext
    {
        public DbSet<Employee>Employees { get; set; }
        public DbSet<UsersId> User { get; set; }


        private readonly IConfiguration _configuration;

        public AplicationContext(DbContextOptions<AplicationContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(t => t.Id);
            modelBuilder.Entity<UsersId>().HasKey(t => t.Id);
        }

    }
}
