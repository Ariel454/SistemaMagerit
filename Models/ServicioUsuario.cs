namespace SistemaMagerit.Models
{
    public interface IAuthService
    {
        Usuario ObtenerUsuario(string nombreUsuario);
        bool ValidarCredenciales(string nombreUsuario, string contraseña);
    }

    public class AuthService : IAuthService
    {
        private List<Usuario> _usuarios;

        public AuthService()
        {
            // Puedes cargar usuarios desde una base de datos u otra fuente de datos
            _usuarios = new List<Usuario>
        {
            new Usuario { NombreUsuario = "admin", Contraseña = "admin123" }
            // Agrega más usuarios según sea necesario
        };
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            return _usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }

        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            var usuario = ObtenerUsuario(nombreUsuario);
            return usuario != null && usuario.Contraseña == contraseña;

        }
    }

}
