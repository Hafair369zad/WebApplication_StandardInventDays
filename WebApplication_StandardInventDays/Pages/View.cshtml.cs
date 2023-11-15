using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_StandardInventDays.Data;
using WebApplication_StandardInventDays.Models;

namespace WebApplication_StandardInventDays.Pages
{
    public class ViewModel : PageModel
    {
        private readonly SidprojectDBContext _context;

        public ViewModel(SidprojectDBContext context)
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
