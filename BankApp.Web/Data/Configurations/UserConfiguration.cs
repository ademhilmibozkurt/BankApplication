using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// user configuration file configures User objects properties
namespace BankApp.Web.Data.Configurations
{
    // type of User IEntityTypeConfiguration interface implementation 
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // property settings
            builder.Property(x=> x.FirstName).HasMaxLength(100);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x=> x.LastName).HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired();

            // many to one relationship. Accounts -> Many, User -> One with UserId property on Account 
            builder.HasMany(x => x.Accounts).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
