namespace BankApp.Web.Models
{
    // money sending model object identity
    public class SendMoneyModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int Amount { get; set; }
    }
}
