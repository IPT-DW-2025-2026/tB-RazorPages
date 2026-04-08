using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tB_University.Data;
using tB_University.Models;

namespace tB_University.Pages.Degrees
{
    public class EditModel : PageModel
    {
        private readonly tB_University.Data.ApplicationDbContext _context;

        public EditModel(tB_University.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree =  await _context.Degrees.FirstOrDefaultAsync(m => m.Id == id);
            if (degree == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("Degree", degree.Name);
            
            Degree = degree;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var nomeAntigoDaBd = HttpContext.Session.GetString("Degree");
            if (Degree.Name != nomeAntigoDaBd)
            {
                ModelState.AddModelError("", "Não é possível alterar o nome do curso depois de criado");
            }
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Attach(Degree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(Degree.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DegreeExists(int id)
        {
            return _context.Degrees.Any(e => e.Id == id);
        }
    }
}
