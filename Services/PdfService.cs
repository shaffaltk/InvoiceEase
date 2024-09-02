using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;

namespace BillingSystem.Services
{
    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GenerateInvoicePdf(Billing billing)
        {
            var document = new HtmlToPdfDocument
            {
                GlobalSettings = {
                    DocumentTitle = "Invoice",
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings {
                        HtmlContent = GenerateHtmlContent(billing),
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(document);
        }

        private string GenerateHtmlContent(Billing billing)
        {
        
            return $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; }}
                        .invoice {{ width: 100%; border-collapse: collapse; }}
                        .invoice th, .invoice td {{ border: 1px solid #ddd; padding: 8px; }}
                        .invoice th {{ background-color: #f2f2f2; }}
                    </style>
                </head>
                <body>
                    <h1>Invoice</h1>
                    <table class='invoice'>
                        <tr><th>Screen License Id</th><td>{billing.ScreenLicenseId}</td></tr>
                        <tr><th>Month/Year</th><td>{billing.MonthYear}</td></tr>
                        <tr><th>Amount</th><td>{billing.Amount.ToString("C")}</td></tr>
                        <tr><th>Billed Date</th><td>{billing.BilledDate.ToString("d")}</td></tr>
                        <tr><th>Payment Status</th><td>{(billing.PaymentStatus ? "Paid" : "Unpaid")}</td></tr>
                    </table>
                </body>
                </html>";
        }
    }
}
