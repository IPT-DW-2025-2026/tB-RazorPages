using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tB_University.Pages.Registration;

public class ViewRegistrations : PageModel
{
    
    public async Task<IActionResult> OnGet()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Redirect("~/Identity/Account/Login");
        }
        
        return Page();
    }
}