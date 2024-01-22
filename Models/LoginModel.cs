using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using SistemaMagerit.Models;
namespace SeguridadInformática.Models;
public class LoginModel : PageModel
{
    private readonly IAuthService _authService;

    [BindProperty]
    public string NombreUsuario { get; set; }

    [BindProperty]
    public string Contraseña { get; set; }

    public LoginModel(IAuthService authService)
    {
        _authService = authService;
    }

    public IActionResult OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            return Redirect("Views/Activos/Index.cshtml");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (_authService.ValidarCredenciales(NombreUsuario, Contraseña))
        {
            // Inicio de sesión exitoso, redirige a la página de inicio
            return Redirect("Views/Activos/Index.cshtml");
        }

        // Credenciales inválidas, muestra un mensaje de error
        ModelState.AddModelError(string.Empty, "Credenciales inválidas");
        return Page();
    }
}