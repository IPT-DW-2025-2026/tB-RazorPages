using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tB_University.Data;

namespace tB_University.Pages.Registration;

[Authorize]
public class ViewRegistrations : PageModel
{
    private readonly ApplicationDbContext _context;

    public ViewRegistrations(ApplicationDbContext context)
    {
        _context = context;
    }

    // Variaveis de Leitura
    public List<tB_University.Models.Registration> listaInscricoes = [];
    
    public async Task<IActionResult> OnGet()
    {
        listaInscricoes = _context.Registrations
            .Include(r => r.Student)
            .Include(r => r.Course)
            .ToList();
        
        return Page();
    }
}