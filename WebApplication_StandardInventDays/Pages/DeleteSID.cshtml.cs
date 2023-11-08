using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Pages
{
    public class DeleteSIDModel : PageModel
    {
        private readonly WebApplication_StandardInventDays.Data.SidprojectDBContext _context;

        public DeleteSIDModel(WebApplication_StandardInventDays.Data.SidprojectDBContext context)
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
            else
            {
                Sid = sid;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Sids == null)
            {
                return NotFound();
            }
            var sid = await _context.Sids.FindAsync(id);

            if (sid != null)
            {
                Sid = sid;
                _context.Sids.Remove(Sid);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./View");
        }
    }
}
