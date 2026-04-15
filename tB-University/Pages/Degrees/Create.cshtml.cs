using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tB_University.Data;
using tB_University.Models;
using tB_University.ValidationClasses;

namespace tB_University.Pages.Degrees
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
            return Page();
        }

        [BindProperty]
        public Degree Degree { get; set; } = default!;

        [BindProperty]
        public IFormFile DegreePhoto { get; set; } = null;
        
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // VALIDAÇÕES CUSTOM
                // 10000000 é o equivalente a 10MB
                if (DegreePhoto.Length > CustomValidationFile.MaxFileSize)
                {
                    ModelState.AddModelError("DegreePhoto", "O ficheiro não pode ter mais de 10 bytes");
                }

                if (DegreePhoto.ContentType != CustomValidationFile.FileContentTypeJpg &&
                    DegreePhoto.ContentType != CustomValidationFile.FileContentTypePng)
                {
                    // exemplo de exception que pode ser apanhada no try catch
                    //throw new Exception("Exception ao conectar à BD");
                    ModelState.AddModelError("DegreePhoto", "O ficheiro tem de ser jpg ou png");
                }
            
            
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Degrees.Add(Degree);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {   
                ModelState.AddModelError("", "Erro ao processar o pedido, por favor tente mais tarde");
                return Page();
            }
            
        }
    }
}
