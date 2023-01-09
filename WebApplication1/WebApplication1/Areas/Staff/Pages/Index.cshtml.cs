using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Areas.Staff.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Context.MyDbContext _context;

        public IndexModel(WebApplication1.Context.MyDbContext context)
        {
            _context = context;
        }

        public IList<Entities.Staff> Staff { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Staff != null)
            {
                Staff = await _context.Staff.ToListAsync();
            }
        }
    }
}
