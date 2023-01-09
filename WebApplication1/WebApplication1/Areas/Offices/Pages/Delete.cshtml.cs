using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Areas.Offices.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Context.MyDbContext _context;

        public DeleteModel(WebApplication1.Context.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Office Office { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Offices == null)
            {
                return NotFound();
            }

            var office = await _context.Offices.FirstOrDefaultAsync(m => m.Id == id);

            if (office == null)
            {
                return NotFound();
            }
            else 
            {
                Office = office;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Offices == null)
            {
                return NotFound();
            }
            var office = await _context.Offices.FindAsync(id);

            if (office != null)
            {
                Office = office;
                _context.Offices.Remove(Office);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
