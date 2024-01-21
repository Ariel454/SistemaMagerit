namespace SeguridadInformática.Models
{
    public class CategoriaAmenaza
    {
        public string Categoria_Amenaza { get; set; }
        public string Amenaza { get; set; }

        private static List<string> categorias = new List<string>();
        private static List<string> amenazasNaturales = new List<string>();
        private static List<string> amenazasIndustriales = new List<string>();
        private static List<string> amenazasNoIntencionadas = new List<string>();
        private static List<string> amenazasIntencionadas = new List<string>();

        public CategoriaAmenaza()
        {
            SetearListasDeAmenazas();
        }

        public CategoriaAmenaza(string categoria, string amenaza)
        {
            Categoria_Amenaza = categoria;
            Amenaza = amenaza;
        }

        public void SetearListasDeAmenazas()
        {
            // Aquí iría la lógica para inicializar las listas de amenazas
            // Similar a la implementación en Java
        }

        public List<string> DevolverAmenazasSegunCategoria(string Categoria_Amenaza)
        {
            switch (Categoria_Amenaza)
            {
                case "DESASTRES_NATURALES":
                    return amenazasNaturales;
                case "ORIGEN_INDUSTRIAL":
                    return amenazasIndustriales;
                case "NO_INTENCIONADOS":
                    return amenazasNoIntencionadas;
                case "ATAQUES_INTENCIONADOS":
                    return amenazasIntencionadas;
                default:
                    return null;
            }
        }

        // Propiedades para acceder a las listas de amenazas
        public static List<string> Categorias => categorias;
        public static List<string> AmenazasNaturales => amenazasNaturales;
        public static List<string> AmenazasIndustriales => amenazasIndustriales;
        public static List<string> AmenazasNoIntencionadas => amenazasNoIntencionadas;
        public static List<string> AmenazasIntencionadas => amenazasIntencionadas;
    }
}