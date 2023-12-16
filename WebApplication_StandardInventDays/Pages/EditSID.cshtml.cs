using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Pages
{
    public class EditSIDModel : PageModel
    {
        private readonly WebApplication_StandardInventDays.Data.SidprojectDBContext _context;

        public EditSIDModel(WebApplication_StandardInventDays.Data.SidprojectDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sid Sid { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Sids == null)
            {
                return NotFound();
            }

            var sid = await _context.Sids.FirstOrDefaultAsync(m => m.IdSid == id);
            if (sid == null)
            {
                return NotFound();
            }
            Sid = sid;
            ViewData["IdMatList"] = new SelectList(_context.MaterialLists, "IdMatList", "IdMatList");
            ViewData["ItemNo"] = new SelectList(_context.MaterialLists, "ItemNo", "ItemNo");
            ViewData["ItemDesc"] = new SelectList(_context.MaterialLists, "ItemDesc", "ItemDesc");
            ViewData["UoM"] = new SelectList(_context.MaterialLists, "UoM", "UoM");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SidExists(Sid.IdSid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SidExists(string id)
        {
            return (_context.Sids?.Any(e => e.IdSid == id)).GetValueOrDefault();
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
