namespace SeguridadInformática.Models
{
    public static class GuardadoDatos
    {
        private static List<Activo> activosCreados = new List<Activo>();
        private static List<Riesgo> riesgosCreados = new List<Riesgo>();
        private static List<Control> controlesCreados = new List<Control>();

        // Métodos para Controles
        public static bool AgregarControl(Control controlNuevo)
        {
            if (BuscarControlPorNombre(controlNuevo.Nombre) == null)
            {
                controlesCreados.Add(controlNuevo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Control BuscarControlPorNombre(string nombreBuscar)
        {
            foreach (var control in controlesCreados)
            {
                if (control.Nombre == nombreBuscar)
                {
                    return control;
                }
            }
            return null;
        }

        public static List<Control> GetControles()
        {
            return controlesCreados;
        }

        // Métodos para Riesgos
        public static bool AgregarRiesgo(Riesgo riesgoNuevo)
        {
            if (BuscarRiesgoPorNombre(riesgoNuevo.Nombre) == null)
            {
                riesgosCreados.Add(riesgoNuevo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Riesgo BuscarRiesgoPorNombre(string nombreBuscar)
        {
            foreach (var riesgo in riesgosCreados)
            {
                if (riesgo.Nombre == nombreBuscar)
                {
                    return riesgo;
                }
            }
            return null;
        }

        public static List<Riesgo> GetRiesgos()
        {
            return riesgosCreados;
        }

        // Métodos para Activos
        public static bool AgregarActivo(Activo activoNuevo)
        {
            if (BuscarActivoPorCodigo(activoNuevo.Id_Activo) == null && BuscarActivoPorNombre(activoNuevo.Nombre) == null)
            {
                activosCreados.Add(activoNuevo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Activo> GetActivos()
        {
            return activosCreados;
        }

        public static Activo BuscarActivoPorCodigo(string codigoBuscar)
        {
            foreach (var activo in activosCreados)
            {
                if (activo.Id_Activo == codigoBuscar)
                {
                    return activo;
                }
            }
            return null;
        }

        public static Activo BuscarActivoPorNombre(string nombreBuscar)
        {
            foreach (var activo in activosCreados)
            {
                if (activo.Nombre == nombreBuscar)
                {
                    return activo;
                }
            }
            return null;
        }

        public static Activo EliminarActivoPorCodigo(string codigoBuscar)
        {
            for (int i = 0; i < activosCreados.Count; i++)
            {
                if (activosCreados[i].Id_Activo == codigoBuscar)
                {
                    var activoAux = activosCreados[i];
                    activosCreados.RemoveAt(i);
                    return activoAux;
                }
            }
            return null;
        }
    }
}