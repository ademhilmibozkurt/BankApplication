using BankApp.Web.Data.Configurations;
using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

// User
// Account
// UserConfiguration
// AccountConfiguration

namespace BankApp.Web.Data.Context
{
    // DbContext, represents a session with the database and can be used to query and save instances of your entities.
    // BankContext, inherits DbContext.
    public class BankContext : DbContext
    { 
        // User, Account Set(küme)'s from database
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }


        // base class ctor called first
        // parametered ctor 
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
            
        }

        // modelBuilder, set of configuration options
        // configures models before creating database 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // run configuration files during model creating
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
