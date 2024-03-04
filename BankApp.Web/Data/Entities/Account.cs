namespace BankApp.Web.Data.Entities
{
    // user account entity. provides account object identity
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserId { get; set; }

        //navigation property for User
        public User User { get; set; }
    }
}
