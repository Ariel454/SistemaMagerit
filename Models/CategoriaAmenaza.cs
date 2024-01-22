namespace SeguridadInformática.Models
{
    public class CategoriaAmenaza
    {
        public string Categoria_Amenaza { get; set; }
        public string Amenaza { get; set; }

        public static List<string> categorias = new List<string>();
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
            //Categorías de amenazas

            //#0
            categorias.Add("DESASTRES_NATURALES");
            //#1
            categorias.Add("ORIGEN_INDUSTRIAL");
            //#2
            categorias.Add("NO_INTENCIONADOS");
            //#3
            categorias.Add("ATAQUES_INTENCIONADOS");

            //Amenazas de categoría: DESASTRES_NATURALES
            //#0
            amenazasNaturales.Add("Fuego");
            //#1
            amenazasNaturales.Add("Daños Por Agua");
            //#2
            amenazasNaturales.Add("Desastres Naturales");

            //Amenazas de categoría: ORIGEN_INDUSTRIAL
            //#0
            amenazasIndustriales.Add("Fuego");
            //#1
            amenazasIndustriales.Add("Daños Por Agua");
            //#2
            amenazasIndustriales.Add("Desastres Industriales");
            //#3
            amenazasIndustriales.Add("Contaminación Mecánica");
            //#4
            amenazasIndustriales.Add("Contaminación Electromagnética");
            //#5
            amenazasIndustriales.Add("Avería de Origen Físico o Lógico");
            //#6
            amenazasIndustriales.Add("Corte del Suministro Eléctrico");
            //#7
            amenazasIndustriales.Add("Condiciones Inadecuadas de Temperatura o Humedad");
            //#8
            amenazasIndustriales.Add("Fallo de Servicios de Comunicaciones");
            //#9
            amenazasIndustriales.Add("Interrupciones de Servicios y Suministros Esenciales");
            //#10
            amenazasIndustriales.Add("Degradación de Soportes de Almacenamiento de Información");
            //#11
            amenazasIndustriales.Add("Emanaciones Electromagnéticas");
            //#12
            amenazasIndustriales.Add("Corte del Suministro Eléctrico");

            //Amenazas de categoría: NO_INTENCIONADOS
            //#0
            amenazasNoIntencionadas.Add("Errores de los Usuarios");
            //#1
            amenazasNoIntencionadas.Add("Errores del Administrador");
            //#2
            amenazasNoIntencionadas.Add("Error de monitorización");
            //#3
            amenazasNoIntencionadas.Add("Errores de Configuración");
            //#4
            amenazasNoIntencionadas.Add("Deficiencias de la Organización");
            //#5
            amenazasNoIntencionadas.Add("Difusión de Software Dañino");
            //#6
            amenazasNoIntencionadas.Add("Errores de Re-encaminamiento");
            //#7
            amenazasNoIntencionadas.Add("Errores de Secuencia");
            //#8
            amenazasNoIntencionadas.Add("Escapes de Información");
            //#9
            amenazasNoIntencionadas.Add("Alteración Accidental de la Información");
            //#10
            amenazasNoIntencionadas.Add("Destrucción de la Información");
            //#11
            amenazasNoIntencionadas.Add("Fugas de Información");
            //#12
            amenazasNoIntencionadas.Add("Vulnerabilidades de los Programas");
            //#13
            amenazasNoIntencionadas.Add("Errores de Mantenimiento/Actualización Programas");
            //#14
            amenazasNoIntencionadas.Add("Errores de Mantenimiento/Actualización Hardware");
            //#15
            amenazasNoIntencionadas.Add("Caída del Sistema por Agotamiento de Recursos");
            //#16
            amenazasNoIntencionadas.Add("Pérdida de Equipos");
            //#17
            amenazasNoIntencionadas.Add("Indisponibilidad del Personal");


            //Amenazas de categoría: ATAQUES_INTENCIONADOS
            //#0
            amenazasIntencionadas.Add("Manipulación de los Registros de Actividad");
            //#1
            amenazasIntencionadas.Add("Manipulación de Configuración");
            //#2
            amenazasIntencionadas.Add("Suplantación de la Identidad del Usuario");
            //#3
            amenazasIntencionadas.Add("Abuso de Privilegios de Acceso");
            //#4
            amenazasIntencionadas.Add("Uso no Previsto");
            //#5
            amenazasIntencionadas.Add("Difusión de Software Dañino");
            //#6
            amenazasIntencionadas.Add("Re-encaminamiento de Mensajes");
            //#7
            amenazasIntencionadas.Add("Alteración de Secuencia");
            //#8
            amenazasIntencionadas.Add("Acceso no Autorizado");
            //#9
            amenazasIntencionadas.Add("Análisis de Tráfico");
            //#10
            amenazasIntencionadas.Add("Repudio");
            //#11
            amenazasIntencionadas.Add("Intercepción de Información");
            //#12
            amenazasIntencionadas.Add("Modificación Deliberada de la Información");
            //#13
            amenazasIntencionadas.Add("Destrucción de la Información");
            //#14
            amenazasIntencionadas.Add("Divulgación de Información");
            //#15
            amenazasIntencionadas.Add("Manipulación de Programas");
            //#16
            amenazasIntencionadas.Add("Manipulación de los Equipos");
            //#17
            amenazasIntencionadas.Add("Denegación de Servicio");
            //#18
            amenazasIntencionadas.Add("Robo");
            //#19
            amenazasIntencionadas.Add("Ataque Destructivo");
            //#20
            amenazasIntencionadas.Add("Ocupación Enemiga");
            //#21
            amenazasIntencionadas.Add("Indisponibilidad del Personal:");
            //#22
            amenazasIntencionadas.Add("Extorsión");
            //#23
            amenazasIntencionadas.Add("Ingeniería Social");
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