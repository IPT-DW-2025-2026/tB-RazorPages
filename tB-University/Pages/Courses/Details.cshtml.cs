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
    public class DetailsModel : PageModel
    {
        private readonly tB_University.Data.ApplicationDbContext _context;

        public DetailsModel(tB_University.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // necessário include para carregar os dados de outras tabelas
            //      dados referentes a fks
            var course = await _context.Courses
                .Include(c => c.Degree)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (course is not null)
            {
                Course = course;

                return Page();
            }

            return NotFound();
        }
    }
}
