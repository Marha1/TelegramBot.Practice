using Domain.Models;
using Infrastructure.Dal.Configurations;
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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

    }
}
