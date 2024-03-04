namespace BankApp.Web.Models
{
    // Account creation model object identity
    public class AccountCreateModel
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserId { get; set; }
    }
}
