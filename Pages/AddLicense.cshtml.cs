using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BillingSystem.Pages
{
public class AddLicenseModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public AddLicenseModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ScreenLicense ScreenLicense { get; set; } =new ScreenLicense();

    public IList<LicenseType> Types { get; set; } =new List<LicenseType>();

    public async Task<IActionResult> OnGetAsync()
    {
        Types = await _context.LicenseTypes.ToListAsync();
        return Page();
    }
    public async Task<JsonResult> OnGetCheckLicenseKeyAsync(string licenseKey)
{
    var exists = await _context.ScreenLicenses.AnyAsync(l => l.LicenseKey == licenseKey);
    return new JsonResult(new { exists });
}


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)

        {

            return Page();
        }
         ScreenLicense.ExpireDate = ScreenLicense.StartDate.AddDays(30);
         _context.ScreenLicenses.Add(ScreenLicense);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

}