namespace BankApp.Web.Models
{
    // AccountModel object identity
    public class AccountModel
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public int UserId { get; set; }
    }
}
