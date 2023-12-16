using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Pages
{
    public class Add_DataModel : PageModel
    {
        private readonly WebApplication_StandardInventDays.Data.SidprojectDBContext _context;

        public Add_DataModel(WebApplication_StandardInventDays.Data.SidprojectDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var materialListItems = _context.MaterialLists.Select(ml => ml.ItemNo).Distinct().ToList();
            ViewData["ItemNo"] = new SelectList(materialListItems);

            // Fetch initial values for Fac and ItemNo from the database
            var initialMaterialList = _context.MaterialLists.FirstOrDefault();

            // Use null-conditional operator to safely assign values
            Sid.Fac = initialMaterialList?.Fac ?? string.Empty;
            Sid.ItemNo = initialMaterialList?.ItemNo ?? string.Empty;

            return Page();
        }


        [BindProperty]
        public Sid Sid { get; set; } = new Sid();



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Sid == null)
            {
                return Page();
            }

            // Fetch additional data from the database if needed
            var materialList = _context.MaterialLists.FirstOrDefault(ml => ml.ItemNo == Sid.ItemNo);

            Sid.ItemDesc = materialList?.ItemDesc;
            Sid.UoM = materialList?.UoM;

            // Save the form data to the database
            _context.Sids.Add(Sid);
            await _context.SaveChangesAsync();

            return RedirectToPage("/View"); // Redirect to the desired page after saving
        }
        
        
        public JsonResult OnGetGetMaterialList(string itemNo)
        {
            // Retrieve MaterialList data based on the selected 'ItemNo'
            var materialList = _context.MaterialLists.FirstOrDefault(ml => ml.ItemNo == itemNo);

            return new JsonResult(new
            {
                ItemDesc = materialList?.ItemDesc,
                UoM = materialList?.UoM
            });
        }
    }
}




//public IActionResult OnGet()
//{
//    ViewData["IdMatList"] = new SelectList(_context.MaterialLists, "IdMatList", "IdMatList");
//    return Page();
//}

//public JsonResult OnGetGetMaterialList(string itemNo)
//{
//    // Retrieve MaterialList data based on the selected 'ItemNo'
//    var materialList = _context.MaterialLists.FirstOrDefault(ml => ml.ItemNo == itemNo);

//    return new JsonResult(new
//    {
//        Fac = materialList?.Fac,
//        ItemDesc = materialList?.ItemDesc,
//        UoM = materialList?.UoM
//    });
//}




