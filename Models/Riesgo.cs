using System.ComponentModel.DataAnnotations;
namespace SeguridadInformática.Models
{
    public class Riesgo
    {
        [Key]
        public int Id_Riesgo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public CategoriaAmenaza CategoriaAmenaza { get; set; }
        public Vulnerabilidades Vulnerabilidad { get; set; }
        public int NivelAceptableDeRiesgo { get; set; }
        public int NivelDeRiesgo { get; set; }
        public string Impacto { get; set; } // Directo - Indirecto
        public int PosibilidadDeOcurrir { get; set; } // 0-7

        // Afecta a un activo
        public Activo ActivoEnRiesgo { get; set; }

        public Riesgo(string nombre, string descripcion, CategoriaAmenaza categoriaAmenaza, Vulnerabilidades vulnerabilidad, int nivelAceptableDeRiesgo, int nivelDeRiesgo, string impacto, int posibilidadDeOcurrir, Activo activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CategoriaAmenaza = categoriaAmenaza;
            Vulnerabilidad = vulnerabilidad;
            NivelAceptableDeRiesgo = nivelAceptableDeRiesgo;
            NivelDeRiesgo = nivelDeRiesgo;
            Impacto = impacto;
            PosibilidadDeOcurrir = posibilidadDeOcurrir;
            ActivoEnRiesgo = activo;
        }

        public bool ModificarRiesgo(Riesgo riesgoNuevo)
        {
            Nombre = riesgoNuevo.Nombre;
            Descripcion = riesgoNuevo.Descripcion;
            CategoriaAmenaza = riesgoNuevo.CategoriaAmenaza;
            Vulnerabilidad = riesgoNuevo.Vulnerabilidad;
            NivelAceptableDeRiesgo = riesgoNuevo.NivelAceptableDeRiesgo;
            NivelDeRiesgo = riesgoNuevo.NivelDeRiesgo;
            Impacto = riesgoNuevo.Impacto;
            PosibilidadDeOcurrir = riesgoNuevo.PosibilidadDeOcurrir;
            ActivoEnRiesgo = riesgoNuevo.ActivoEnRiesgo;

            return true;
        }

        // Otros métodos get y set...

        public override string ToString()
        {
            return $"Riesgo{{nombre={Nombre}, descripcion={Descripcion}, categoriaAmenaza={CategoriaAmenaza}, vulnerabilidad={Vulnerabilidad}, nivelAceptableDeRiesgo={NivelAceptableDeRiesgo}, nivelDeRiesgo={NivelDeRiesgo}, impacto={Impacto}, posibilidadDeOCurrir={PosibilidadDeOcurrir}}}";
        }
    }
}
