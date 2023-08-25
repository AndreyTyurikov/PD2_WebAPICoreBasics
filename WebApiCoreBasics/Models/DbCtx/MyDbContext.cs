using Microsoft.EntityFrameworkCore;
using WebApiCoreBasics.Models.Entities;

namespace WebApiCoreBasics.Models.DbCtx
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration AppConfiguration = 
                new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString("MyDbConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
