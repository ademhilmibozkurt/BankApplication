namespace BankApp.Web.Data.Entities
{
    // user entity. provides a user object identity
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // navigation property for Account
        public List<Account> Accounts { get; set; }
    }
}
