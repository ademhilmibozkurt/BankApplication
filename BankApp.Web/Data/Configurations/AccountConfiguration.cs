using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// account configuration file configures Account objects properties
namespace BankApp.Web.Data.Configurations
{
    // type of Account IEntityTypeConfiguration interface implementation 
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // property settings
            builder.Property(x=> x.AccountNumber).IsRequired();
            builder.Property(x=> x.Balance).HasColumnType("decimal(18,4)");
            builder.Property(x=> x.Balance).IsRequired();
        }
    }
}
