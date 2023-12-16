using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using WebApplication_StandardInventDays.Data;
using WebApplication_StandardInventDays.Models;

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
                    .Include(s => s.IdMatListNavigation)
                    .ToListAsync();
            }
        }

        public IActionResult OnGetDownloadExcel()
        {
            var stream = new MemoryStream();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("SID Data");

                // Add header row
                worksheet.Cell(1, 1).Value = "No";
                worksheet.Cell(1, 2).Value = "Fac";
                worksheet.Cell(1, 3).Value = "ItemNo";
                worksheet.Cell(1, 4).Value = "ItemDesc";
                worksheet.Cell(1, 5).Value = "UoM";
                worksheet.Cell(1, 6).Value = "VendorType";
                worksheet.Cell(1, 7).Value = "ProdLt";
                worksheet.Cell(1, 8).Value = "MonthlyConsume";
                worksheet.Cell(1, 9).Value = "CapacityDifferent";
                worksheet.Cell(1, 10).Value = "DeliveryCycle";
                worksheet.Cell(1, 11).Value = "Consumption";
                worksheet.Cell(1, 12).Value = "Reject";
                worksheet.Cell(1, 13).Value = "MoQ";
                worksheet.Cell(1, 14).Value = "Hasil";

                // Add data rows    
                int row = 2;
                int No = 1;
                foreach (var item in Sid)
                {
                    worksheet.Cell(row, 1).Value = No++;
                    if (item != null)
                    {
                        worksheet.Cell(row, 2).Value = item.Fac ?? string.Empty;
                        worksheet.Cell(row, 3).Value = item.ItemNo ?? string.Empty;
                        worksheet.Cell(row, 4).Value = item.ItemDesc ?? string.Empty;
                        worksheet.Cell(row, 5).Value = item.UoM ?? string.Empty;
                        worksheet.Cell(row, 6).Value = item.VendorType ?? string.Empty;
                        worksheet.Cell(row, 7).Value = item.ProdLt ?? string.Empty;
                        worksheet.Cell(row, 8).Value = item.MonthlyConsume ?? string.Empty;
                        worksheet.Cell(row, 9).Value = item.CapacityDifferent ?? string.Empty;
                        worksheet.Cell(row, 10).Value = item.DeliveryCycle ?? string.Empty;
                        worksheet.Cell(row, 11).Value = item.Consumption ?? string.Empty;
                        worksheet.Cell(row, 12).Value = item.Reject ?? string.Empty;
                        worksheet.Cell(row, 13).Value = item.MoQ ?? string.Empty;
                        worksheet.Cell(row, 14).Value = item.Hasil ?? 0.0;
                    }

                    row++;
                }

                workbook.SaveAs(stream);
            }

            stream.Position = 0;

            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SID_Data.xlsx");
        }
    }
}



//public async Task<IActionResult> OnPostDownloadAsync(string fileFormat)
//{
//    var data = await _context.Sids
//        .Select((s, index) => new
//        {
//            No = index + 1,
//            s.Fac,
//            s.ItemNo,
//            s.ItemDesc,
//            s.UoM,
//            s.VendorType,
//            s.ProdLt,
//            s.MonthlyConsume,
//            s.CapacityDifferent,
//            s.DeliveryCycle,
//            s.Consumption,
//            s.Reject,
//            s.MoQ,
//            s.Hasil
//        })
//        .ToListAsync();

//    using (var package = new ExcelPackage())
//    {
//        var worksheet = package.Workbook.Worksheets.Add("SID Data");

//        // Add headers
//        worksheet.Cells["A1"].Value = "No";
//        worksheet.Cells["B1"].Value = "Fac";
//        worksheet.Cells["C1"].Value = "ItemNo";
//        worksheet.Cells["D1"].Value = "ItemDesc";
//        worksheet.Cells["E1"].Value = "UoM";
//        worksheet.Cells["F1"].Value = "VendorType";
//        worksheet.Cells["G1"].Value = "ProdLt";
//        worksheet.Cells["H1"].Value = "MonthlyConsume";
//        worksheet.Cells["I1"].Value = "CapacityDifferent";
//        worksheet.Cells["J1"].Value = "DeliveryCycle";
//        worksheet.Cells["K1"].Value = "Consumption";
//        worksheet.Cells["L1"].Value = "Reject";
//        worksheet.Cells["M1"].Value = "MoQ";
//        worksheet.Cells["N1"].Value = "Hasil";

//        // Add data
//        worksheet.Cells["A2"].LoadFromCollection(data, false);

//        // Create a memory stream and write the package to it
//        using (var memoryStream = new MemoryStream())
//        {
//            package.SaveAs(memoryStream);

//            // Set the position to the beginning of the stream
//            memoryStream.Position = 0;

//            // Return the Excel file
//            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"SID_Data_{DateTime.Now.ToString("yyyyMMddHHmmss")}.{fileFormat}");
//        }
//    }
//}


