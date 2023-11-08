using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_StandardInventDays.Data;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication_StandardInventDays.Data.SidprojectDBContext _context;

        public CreateModel(WebApplication_StandardInventDays.Data.SidprojectDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdMatList"] = new SelectList(_context.MaterialLists, "IdMatList", "IdMatList");
            return Page();
        }

        [BindProperty]
        public Sid Sid { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sids == null || Sid == null)
            {
                return Page();
            }

            _context.Sids.Add(Sid);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
