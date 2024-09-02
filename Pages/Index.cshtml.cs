using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Pages
{
    public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
        
    }

    public IList<ScreenLicense> ScreenLicenses { get; set; }
    public IList<LicenseType> LicenseTypes { get; set; }

    public async Task OnGetAsync()
    {
        ScreenLicenses = await _context.ScreenLicenses
            .Include(s => s.LicenseType) // Include the LicenseType entity
            .ToListAsync();
        LicenseTypes = await _context.LicenseTypes.ToListAsync();
    }
}
}
