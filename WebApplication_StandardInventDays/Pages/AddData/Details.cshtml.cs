using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Data;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication_StandardInventDays.Data.SidprojectDBContext _context;

        public DetailsModel(WebApplication_StandardInventDays.Data.SidprojectDBContext context)
        {
            _context = context;
        }

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
    }
}
