using Microsoft.AspNetCore.Mvc;
using SeguridadInformática.Models;
using SistemaMagerit.Models;

namespace SistemaMagerit.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Si ya está autenticado, redirige a la acción Index del controlador Activos
                return RedirectToAction ("Index", "Activos");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            if (_authService.ValidarCredenciales(loginModel.NombreUsuario, loginModel.Contraseña))
            {
                // Inicio de sesión exitoso, redirige a la acción Index del controlador Activos
                return RedirectToAction ("Index", "Activos");
            }

            // Credenciales inválidas, muestra un mensaje de error
            ModelState.AddModelError(string.Empty, "Credenciales inválidas");
            return View();
        }
    }
}
