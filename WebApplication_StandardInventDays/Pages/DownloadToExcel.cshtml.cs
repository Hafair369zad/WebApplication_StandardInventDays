using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Data;
using WebApplication_StandardInventDays.Models;
using OfficeOpenXml;
using System.IO;

namespace WebApplication_StandardInventDays.Pages
{
    public class DownloadToExcelModel : PageModel
    {
        private readonly SidprojectDBContext _context;

        public DownloadToExcelModel(SidprojectDBContext context)
        {
            _context = context;
        }

        public IList<Sid> Sid { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sids != null)
            {
                Sid = await _context.Sids
                .Include(s => s.IdMatListNavigation).ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostDownloadAsync(string fileFormat)
        {
            var data = await _context.Sids
                .Select((s, index) => new
                {
                    No = index + 1,
                    s.Fac,
                    s.ItemNo,
                    s.ItemDesc,
                    s.UoM,
                    s.VendorType,
                    s.ProdLt,
                    s.MonthlyConsume,
                    s.CapacityDifferent,
                    s.DeliveryCycle,
                    s.Consumption,
                    s.Reject,
                    s.MoQ,
                    s.Hasil
                })
                .ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("SID Data");

                // Add headers
                worksheet.Cells["A1"].Value = "No";
                worksheet.Cells["B1"].Value = "Fac";
                worksheet.Cells["C1"].Value = "ItemNo";
                worksheet.Cells["D1"].Value = "ItemDesc";
                worksheet.Cells["E1"].Value = "UoM";
                worksheet.Cells["F1"].Value = "VendorType";
                worksheet.Cells["G1"].Value = "ProdLt";
                worksheet.Cells["H1"].Value = "MonthlyConsume";
                worksheet.Cells["I1"].Value = "CapacityDifferent";
                worksheet.Cells["J1"].Value = "DeliveryCycle";
                worksheet.Cells["K1"].Value = "Consumption";
                worksheet.Cells["L1"].Value = "Reject";
                worksheet.Cells["M1"].Value = "MoQ";
                worksheet.Cells["N1"].Value = "Hasil";

                // Add data
                worksheet.Cells["A2"].LoadFromCollection(data, false);

                // Create a memory stream and write the package to it
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);

                    // Set the position to the beginning of the stream
                    memoryStream.Position = 0;

                    // Return the Excel file
                    return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"SID_Data_{DateTime.Now.ToString("yyyyMMddHHmmss")}.{fileFormat}");
                }
            }
        }

    }
}
