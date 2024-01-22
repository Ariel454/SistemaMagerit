using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeguridadInformática.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SistemaMagerit.Controllers
{
public class ControlesController : Controller
    {
        // Lista estática para almacenar los controles
        public static List<Control> listaDeControles = new List<Control>()
          {
            new Control { Nombre = "Modificacion_Del_Riesgo", Descripcion = "Descripción 1", TipoControl = null, Eficacia = 5 },
            new Control { Nombre = "Retencion_Del_Riesgo", Descripcion = "Descripción 2", TipoControl = null, Eficacia = 7 },
            // Agrega más controles según sea necesario
           };



        // GET: ControlesController
        public ActionResult Index()
        {
            // Pasa la lista de controles como modelo
            return View("Views/Controles/Index.cshtml", listaDeControles);
        }

        // GET: ControlesController/Create
        public IActionResult Create()
        {
            // Preparar datos para los ComboBox
   
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            ViewBag.EficaciaOptions = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<SelectListItem> itemsDeControles = listaDeControles
            .Select(control => new SelectListItem { Text = control.Nombre, Value = control.Nombre })
                .ToList();

            // Pasar la lista de SelectListItem a SelectList
            ViewBag.ListaControles = new SelectList(itemsDeControles, "Value", "Text");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Control control)
        {
            // Verificar si ya existe un control con el mismo nombre
            if (BuscarControlPorNombre(control.Nombre) == null)
            {
                // Agregar el nuevo control a la lista
                listaDeControles.Add(control);

                // Redirigir a la acción Index
                return RedirectToAction("Index");
            }

            // Si ya existe un control con el mismo nombre, puedes manejarlo según tus necesidades
            ModelState.AddModelError("Nombre", "Ya existe un control con este nombre.");
            return View(control);
        }

        // GET: ControlesController/Details/5
        public ActionResult Details(string nombre)
        {
            Control control = listaDeControles.FirstOrDefault(c => c.Nombre == nombre);

            if (control == null)
            {
                // Si no se encuentra el control, redirigir al listado de controles
                return RedirectToAction("Index");
            }

            // Preparar ViewBag para los dropdowns en la vista de detalles
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            ViewBag.EficaciaOptions = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return View(control);
        }

        // GET: ControlesController/Edit/5
       public ActionResult Edit(string nombre)
        {
            // Buscar el control en la lista por el nombre utilizando el método BuscarControlPorNombre
            Control control = listaDeControles.FirstOrDefault(c => c.Nombre == nombre);
            Console.WriteLine("##############################"+control.Nombre);

            if (control == null)
            {
                   // Si no se encuentra el control, redirigir al listado de controles
                return RedirectToAction("Index");
            }

            // Preparar ViewBag para los dropdowns en la vista de edición
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            ViewBag.EficaciaOptions = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Agrega más ViewBag según sea necesario
            List<SelectListItem> itemsDeControles = listaDeControles
            .Select(control => new SelectListItem { Text = control.Nombre, Value = control.Nombre })
            .ToList();

            // Pasar la lista de SelectListItem a SelectList
            ViewBag.ListaControles = new SelectList(itemsDeControles, "Value", "Text");


            return View(control);
        }


        // POST: Controles/Edit/Modificacion_Del_Riesgo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string nombre, Control control)
        {
            if (ModelState.IsValid)
            {
                // Buscar el control en la lista por el nombre proporcionado
                Control controlExistente = listaDeControles.FirstOrDefault(c => c.Nombre == nombre);

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
        public ActionResult Delete(string nombre)
        {
            Control controlEliminar = BuscarControlPorNombre(nombre);

            if (controlEliminar != null)
            {
                listaDeControles.Remove(controlEliminar);
            }

            return RedirectToAction(nameof(Index));
        }

        // Función para buscar un control por nombre
        private Control BuscarControlPorNombre(string nombre)
        {
            return listaDeControles.FirstOrDefault(c => c.Nombre == nombre);
        }

        private void ConfigurarViewBag()
        {
            ViewBag.TipoControlOptions = Enum.GetValues(typeof(TipoControl));
            // Configura otros datos necesarios en el ViewBag
        }
    }
}
