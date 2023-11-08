using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Data;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Pages.AddData
{
    public class IndexModel : PageModel
    {
        private readonly SidprojectDBContext _context;

        public IndexModel(SidprojectDBContext context)
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
    }
}
