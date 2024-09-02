using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Pages{

public class BillingModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public BillingModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Billing> Billings { get; set; } = default!;

    public async Task OnGetAsync()
    {
        
        var currentDate = DateTime.Now;

    
        Billings = await _context.ScreenLicenses
            .Where(sl => sl.ExpireDate < currentDate)
            .Select(sl => new Billing
            {
                ScreenLicenseId = sl.ScreenLicenseId,
                MonthYear = $"{sl.StartDate:MM/yyyy}", 
                Amount = sl.LicenseType!.MonthlyCost, 
                BilledDate = currentDate, 
                PaymentStatus = false, 
                LicenseTypeId = sl.LicenseTypeId
            })
            .ToListAsync();
    }
}
}
