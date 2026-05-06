using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tB_University.Data;

namespace tB_University.Pages.Registration;

[Authorize(Roles = "Admin")]
public class ViewRegistrations : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ViewRegistrations(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Variaveis de Leitura
    public List<tB_University.Models.Registration> ListaInscricoes = [];
    
    public async Task<IActionResult> OnGet()
    {
        // 1- ter o id da tabela MyUsers
        // 2- adicionar uma clausula where À lista
        var userIdentity = _context.Users.First(u => u.Email == User.Identity.Name);
        var checkRole = await _userManager.GetRolesAsync(userIdentity);

        ListaInscricoes = _context.Registrations
            .Include(r => r.Student)
            .Include(r => r.Course)
            .Where(r => (r.Student.UserId == User.Identity.Name) || (checkRole.Contains("Administrador")))
            .ToList();
        
        return Page();
    }
}