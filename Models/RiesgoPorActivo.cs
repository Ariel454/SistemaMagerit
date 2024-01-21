using SeguridadInformática.Models;

public class RiesgoPorActivo
{
    public int Id_Activo { get; set; }
    public Activo? Activo { get; set; } // Propiedad de navegación hacia Activo

    public int Id_Riesgo { get; set; }
    public Riesgo? Riesgo { get; set; } // Propiedad de navegación hacia Riesgo
}
