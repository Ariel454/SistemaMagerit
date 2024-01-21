namespace SeguridadInformática.Models
{
    public class ActivoConControles
    {
        public int Id_Activo { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public List<string> NombresDeControles { get; set; }
        public ICollection<RiesgoPorActivo> RiesgosPorActivo { get; set; }
    }

}
