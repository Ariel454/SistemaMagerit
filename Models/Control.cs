using System.ComponentModel.DataAnnotations;
namespace SeguridadInformática.Models
{
    public class Control
    {
        [Key]
        public int Id_Control { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public TipoControl Tipo { get; set; }
        public float Eficacia { get; set; }
        private List<Riesgo> riesgos = new List<Riesgo>();
        public Control(string nombre, string descripcion, TipoControl Tipo, float Eficacia)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Tipo = Tipo;
            Eficacia = Eficacia;
        }

        public bool AgregarRiesgo(Riesgo riesgoNuevo)
        {
            if (BuscarRiesgoPorNombre(riesgoNuevo.Nombre) == null)
            {
                riesgos.Add(riesgoNuevo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Riesgo BuscarRiesgoPorNombre(string nombreBuscar)
        {
            foreach (var riesgo in riesgos)
            {
                if (riesgo.Nombre == nombreBuscar)
                {
                    return riesgo;
                }
            }
            return null;
        }

        public List<Riesgo> Riesgos
        {
            get => riesgos;
            set => riesgos = value;
        }

        public override string ToString()
        {
            return $"Control{{nombre={Nombre}, descripcion={Descripcion}, tipoControl={Tipo}, eficaciaEsperada={Eficacia}}}";
        }
    }
}