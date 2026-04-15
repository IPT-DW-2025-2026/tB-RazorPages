using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tB_University.Data;
using tB_University.Models;

namespace tB_University.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly tB_University.Data.ApplicationDbContext _context;

        public IndexModel(tB_University.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _context.Courses
                .Include(c => c.Degree).ToListAsync();
        }
    }
}
