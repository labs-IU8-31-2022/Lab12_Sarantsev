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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Context.MyDbContext _context;

        public DetailsModel(WebApplication1.Context.MyDbContext context)
        {
            _context = context;
        }

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
    }
}
