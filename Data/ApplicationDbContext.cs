
 using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ScreenLicense>? ScreenLicenses { get; set; }
    public DbSet<Billing>? Billings { get; set; }
    public DbSet<LicenseType>? LicenseTypes { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<LicenseType>()
        .HasKey(l => l.LicenseTypeId);

    modelBuilder.Entity<ScreenLicense>()
        .HasKey(s => s.ScreenLicenseId);
    modelBuilder.Entity<ScreenLicense>()
    .HasIndex(sl => sl.LicenseKey)
    .IsUnique();
       

    modelBuilder.Entity<ScreenLicense>()
        .HasOne(s => s.LicenseType)
        .WithMany()
        .HasForeignKey(s => s.LicenseTypeId);

    modelBuilder.Entity<Billing>().HasNoKey();

    modelBuilder.Entity<LicenseType>().HasData(
        new LicenseType { LicenseTypeId = 1, Type = "Standard", MonthlyCost = 50 },
        new LicenseType { LicenseTypeId = 2, Type = "Premium", MonthlyCost = 100 },
        new LicenseType { LicenseTypeId = 3, Type = "Enterprise", MonthlyCost = 200 }
    );

    base.OnModelCreating(modelBuilder);
}


}


     