using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeguridadInformática.Models;


namespace SistemaMagerit.Controllers
{
public class ControlesController : Controller
    {
        // Lista estática para almacenar los controles
<<<<<<< HEAD
        public static List<Control> listaDeControles = new List<Control>()
          {
            //new Control { Nombre = "Modificacion_Del_Riesgo", Descripcion = "Descripción 1", TipoControl = null, Eficacia = 5 },
            //new Control { Nombre = "Retencion_Del_Riesgo", Descripcion = "Descripción 2", TipoControl = null, Eficacia = 7 },
            // Agrega más controles según sea necesario
           };

=======
        public static List<Control> listaDeControles = new List<Control>();
        //public static List<Riesgo> listaDeRiesgos = new List<Riesgo>();
        public static int idCounter = 1;
>>>>>>> bb1daa868e27a638254db5b678eb12107bc2abb3


        // GET: ControlesController
        public ActionResult Index()
        {
            // Pasa la lista de controles como modelo
            return View("Views/Controles/Index.cshtml", listaDeControles);
        }

        // GET: ControlesController/Create
        public IActionResult Create()
        {
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            ViewBag.EficaciaOptions = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Preparar la lista de riesgos para el dropdown
            List<SelectListItem> itemsDeRiesgos = RiesgosController.listaDeRiesgos
                .Select(riesgo => new SelectListItem { Text = riesgo.Nombre, Value = riesgo.Id_Riesgo.ToString() })
                .ToList();
            ViewBag.ListaRiesgos = new SelectList(itemsDeRiesgos, "Value", "Text");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Control control, string riesgosSeleccionados)
        {
            control.Id_Control = "C0" + idCounter++;
            control.listaDeRiesgos = new List<Riesgo>();

<<<<<<< HEAD
                // Agrega el mensaje a TempData
                TempData["Message"] = "Se ha creado un control";

                // Redirigir a la acción Index
                return RedirectToAction("Index");
=======
            // Asegúrate de que riesgosSeleccionados no sea nulo o vacío antes de procesarlo
            if (!string.IsNullOrWhiteSpace(riesgosSeleccionados))
            {
                var riesgoIds = riesgosSeleccionados.Split(',');
                foreach (var riesgoId in riesgoIds)
                {
                    var riesgoEncontrado = RiesgosController.listaDeRiesgos.FirstOrDefault(riesgo => riesgo.Id_Riesgo == riesgoId.ToString());
                    if (riesgoEncontrado != null)
                    {
                        control.listaDeRiesgos.Add(riesgoEncontrado);
                    }
                    else
                    {
                        System.Console.WriteLine("No agrega no se xq");
                    }
                }
>>>>>>> bb1daa868e27a638254db5b678eb12107bc2abb3
            }

            listaDeControles.Add(control);

            return RedirectToAction("Index");
        }
        // GET: ControlesController/Details/5
        public ActionResult Details(string Id_Control)
        {
            Control control = BuscarControlPorId(Id_Control);
            /*
            if (control == null)
            {
                // Si no se encuentra el control, redirigir al listado de controles
                return RedirectToAction("Index");
            }*/

            // Preparar ViewBag para los dropdowns en la vista de detalles
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            ViewBag.EficaciaOptions = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return View(control);
        }

        // GET: ControlesController/Edit/5
       public ActionResult Edit(string Id_Control)
        {
            // Buscar el control en la lista por el nombre utilizando el método BuscarControlPorNombre
            Control control = BuscarControlPorId(Id_Control);

            // Preparar ViewBag para los dropdowns en la vista de edición
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            ViewBag.EficaciaOptions = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Preparar la lista de riesgos para el dropdown
            List<SelectListItem> itemsDeRiesgos = RiesgosController.listaDeRiesgos
                .Select(riesgo => new SelectListItem { Text = riesgo.Nombre, Value = riesgo.Id_Riesgo.ToString() })
                .ToList();
            ViewBag.ListaRiesgos = new SelectList(itemsDeRiesgos, "Value", "Text");


            return View(control);
        }


        // POST: Controles/Edit/Modificacion_Del_Riesgo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string idControl, Control control)
        {
            if (ModelState.IsValid)
            {
                // Buscar el control en la lista por el nombre proporcionado
                Control controlExistente = BuscarControlPorId(idControl);

                if (controlExistente != null)
                {
                    // Aplicar las actualizaciones al control existente
                    controlExistente.Nombre = control.Nombre;
                    controlExistente.Descripcion = control.Descripcion;
                    controlExistente.TipoControl = control.TipoControl;
                    controlExistente.Eficacia = control.Eficacia;

                    // Aquí deberías guardar los cambios en tu almacenamiento persistente (base de datos, etc.).
                    // ...

                    return RedirectToAction(nameof(Index));
                }
            }

            // Si llegamos aquí, algo salió mal, vuelve a cargar la vista con el modelo control
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            ViewBag.EficaciaOptions = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return View(control);
        }


        // GET: ControlesController/Delete/5
        public ActionResult Delete(string Id_Control)
        {
            Control control = BuscarControlPorId(Id_Control);
            listaDeControles.Remove(control);

            return RedirectToAction(nameof(Index));
        }
        // POST: ControlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Función para buscar un control por nombre
        public Control BuscarControlPorId(string Id_Control)
        {
            return listaDeControles.FirstOrDefault(c => c.Id_Control == Id_Control);
        }

        private void ConfigurarViewBag()
        {
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            // Configura otros datos necesarios en el ViewBag
        }
    }
}
