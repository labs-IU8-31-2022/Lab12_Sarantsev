using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Areas.Offices.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Context.MyDbContext _context;

        public CreateModel(WebApplication1.Context.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Office Office { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Offices == null || Office == null)
            {
                return Page();
            }

            _context.Offices.Add(Office);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
