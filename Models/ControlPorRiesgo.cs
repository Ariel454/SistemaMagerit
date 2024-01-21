using SeguridadInformática.Models;
using System.ComponentModel.DataAnnotations;

namespace SeguridadInformática.Models
{
    public class ControlPorRiesgo
    {
        public int Id_Riesgo { get; set; }
        public Riesgo? Riesgo { get; set; } // Propiedad de navegación hacia Riesgo

        public int Id_Control { get; set; }
        public Control? Control { get; set; } // Propiedad de navegación hacia Control
    }
}
