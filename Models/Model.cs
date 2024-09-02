using System.ComponentModel.DataAnnotations;

public class ScreenLicense
{
    public int ScreenLicenseId { get; set; }
    
    public string? LicenseKey { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public int LicenseTypeId { get; set; }

    public LicenseType? LicenseType { get; set; } // Navigation property
}

public class LicenseType
{
    public int LicenseTypeId { get; set; }
    public string? Type { get; set; }
    public int MonthlyCost { get; set; }
}


public class Billing
{
    public int ScreenLicenseId { get; set; }
    public string? MonthYear { get; set; }
    public decimal Amount { get; set; }
    public DateTime BilledDate { get; set; }
    public bool PaymentStatus { get; set; }
    public int LicenseTypeId { get; set; }
}
