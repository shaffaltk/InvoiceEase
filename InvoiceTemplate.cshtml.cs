using Microsoft.AspNetCore.Mvc.RazorPages;
using BillingSystem.Pages;

namespace BillingSystem.Pages
{
    public class InvoiceTemplateModel : PageModel
    {
        public Billing Billing { get; set; } =new Billing();

        public void OnGet(Billing billing)
        {
            Billing = billing ?? new Billing();
        }
    }
}
