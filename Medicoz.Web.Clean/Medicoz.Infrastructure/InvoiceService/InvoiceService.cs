using Medicoz.Application.Contracts.Invoice;
using Medicoz.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

namespace Medicoz.Infrastructure.InvoiceService
{
    public class InvoiceService : IInvoiceCreator
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InvoiceService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public FileContentResult GenerateInvoice(Order order)
        {

            var invoice = new Domain.Invoice
            {
                InvoiceNumber = order.Id,
                InvoiceDate = DateTime.Now,
                CustomerName = order.FullName,
                InvoiceItems = order.Basket.BasketItems.Select(x => new Domain.InvoiceItem
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    ImageUrl = $"~/uploads/images/{x.Product.ImageUrl}"
                }).ToList()
            };

            invoice.TotalPrice = order.Basket.BasketTotal;

            var invoicePdfBytes = GenerateInvoicePdf(invoice, _webHostEnvironment);

            return new FileContentResult(invoicePdfBytes, "application/pdf");

        }

        private byte[] GenerateInvoicePdf(Domain.Invoice invoice, IWebHostEnvironment hostingEnvironment)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            if (PdfSharp.Fonts.GlobalFontSettings.FontResolver is null)
            {
                GlobalFontSettings.FontResolver = new FileFontResolver();
            }

            XFont font = new XFont(GlobalFontSettings.DefaultFontName, 12);

            int y = 20;
            gfx.DrawString($"Invoice Number: {invoice.InvoiceNumber}", font, XBrushes.Black, 20, y);
            y += 20;
            gfx.DrawString($"Invoice Date: {invoice.InvoiceDate.ToShortDateString()}", font, XBrushes.Black, 20, y);
            y += 20;
            gfx.DrawString($"Customer: {invoice.CustomerName}", font, XBrushes.Black, 20, y);
            y += 40;

            foreach (var item in invoice.InvoiceItems)
            {
                gfx.DrawString($"{item.Name}: ${item.Price}", font, XBrushes.Black, 20, y);

                string imagePath = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot", item.ImageUrl.TrimStart('~', '/'));
                if (System.IO.File.Exists(imagePath))
                {
                    XImage image = XImage.FromFile(imagePath);
                    gfx.DrawImage(image, 200, y - 10, 100, 100);
                }
                else
                {

                }

                y += 100;
            }

            gfx.DrawString($"Total: ${invoice.TotalPrice}", font, XBrushes.Black, 20, y);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, false);
            byte[] pdfBytes = stream.ToArray();
            stream.Close();

            return pdfBytes;
        }


    }

    public class FileFontResolver : IFontResolver
    {
        public string DefaultFontName => "Roboto-Black";
        public byte[] GetFont(string faceName)
        {

            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fontFileName = "Roboto-Black.ttf";
            string fontFilePath = Path.Combine(desktopFolderPath, fontFileName);

            if (File.Exists(fontFilePath))
            {
                return File.ReadAllBytes(fontFilePath);
            }
            else
            {
                throw new FileNotFoundException($"Font file '{fontFileName}' not found on the desktop.");
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fontFileName = "Roboto-Black.ttf";
            string fontFilePath = Path.Combine(desktopFolderPath, fontFileName);

            if (File.Exists(fontFilePath))
            {
                return new FontResolverInfo(fontFilePath);
            }
            else
            {
                return null;
            }
        }
    }


}
