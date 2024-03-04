using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;

// this file allows to direction of specific elements by tag name 
namespace BankApp.Web.TagHelpers
{
    // method calling attribute for html tag
    [HtmlTargetElement("getAccountCount")]
    
    // GetAccountCount inherits TagHelper class
    public class GetAccountCount : TagHelper
    {
        public int UserId { get; set; }

        // just readable context
        private readonly BankContext _context;

        // build constructor. DI
        public GetAccountCount(BankContext context)
        {
            _context = context;    
        }

        // do this process when you see "get-Account-Count" tag
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // number of accounts that specific user has
            int accounts = _context.Accounts.Count(x=> x.UserId == this.UserId);
            
            // this is how account count show on html view
            string html = $"<span class= 'badge bg-danger'> {accounts} </span>";
            
            // give html string to content
            output.Content.SetHtmlContent(html);
        }
    }
}
