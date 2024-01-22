using SeguridadInformática.Enums;
using System.ComponentModel.DataAnnotations;

namespace SeguridadInformática.Models
{
    public class Control
    {
        [Key]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get;  set; }
        [Required]
        public string TipoControl { get;  set; }

        [Required]
        public float Eficacia { get; set; }

        //private List<Riesgo> riesgos = new List<Riesgo>();

        public Control(string nombre, string descripcion, string tipoControl, float eficacia)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            TipoControl = tipoControl;
            Eficacia = eficacia;
        }

        public Control()
        {

        }

        public bool ModificarControl(Control controlNuevo)
        {
            Nombre = controlNuevo.Nombre;
            Descripcion = controlNuevo.Descripcion;
            TipoControl = controlNuevo.TipoControl;
            Eficacia = controlNuevo.Eficacia;

            return true;
        }



        // Otros métodos get y set...

        public override string ToString()
        {
            return $"Control{{nombre={Nombre}, descripcion={Descripcion}, tipoControl={TipoControl}, eficacia={Eficacia}}}";
        }

       
    }
}
