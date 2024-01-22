using System.ComponentModel.DataAnnotations;

namespace SeguridadInformática.Models
{
    public class Control
    {
        [Key]
        public string Id_Control { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get;  set; }
        [Required]
        public string TipoControl { get;  set; }

        [Required]
        public float Eficacia { get; set; }

        public List<Riesgo> listaDeRiesgos { get; set; }

        public Control(string Id_Control, string nombre, string descripcion, string tipoControl, float eficacia)
        {
            this.Id_Control = Id_Control;
            Nombre = nombre;
            Descripcion = descripcion;
            TipoControl = tipoControl;
            Eficacia = eficacia;
            listaDeRiesgos = new List<Riesgo>(); // Inicializar la lista de riesgos aquí
        }

        public Control()
        {
            listaDeRiesgos = new List<Riesgo>(); // Inicializar también aquí
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
