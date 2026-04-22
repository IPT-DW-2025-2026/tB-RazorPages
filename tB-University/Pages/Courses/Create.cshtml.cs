using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tB_University.Data;
using tB_University.Models;

namespace tB_University.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly tB_University.Data.ApplicationDbContext _context;

        public CreateModel(tB_University.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DegreeFk"] = new SelectList(_context.Degrees, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        [BindProperty]
        [Display(Name = "Ano da Unidade Curricular")]
        [RegularExpression("[1-2][0-9]{3}[/][1-2][0-9]{3}", ErrorMessage = "O {0} deve seguir o formato yyyy/yyyy.")]
        public string? AnoAux { get; set; } = string.Empty;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DegreeFk"] = new SelectList(_context.Degrees, "Id", "Name");
                return Page();
            }
            var AnoAuxArray =  AnoAux?.Split('/');
            Course.CurricularYear = Convert.ToInt32(AnoAuxArray[0]);

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
