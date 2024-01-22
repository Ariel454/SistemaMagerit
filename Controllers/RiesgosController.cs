using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeguridadInformática.Enums;
using SeguridadInformática.Models;
using System;
using System.Diagnostics.Metrics;

namespace SistemaMagerit.Controllers
{
    public class RiesgosController : Controller
    {

        // Lista estática para almacenar los riesgos
        private static List<Riesgo> listaDeRiesgos = new List<Riesgo>();
        public static int idCounter = 1;

        // GET: RiesgosController
        public ActionResult Index()
        {
            return View("Views/Riesgos/Index.cshtml", listaDeRiesgos);
        }

        // GET: RiesgosController/Create
        public IActionResult Create()
        {
            ViewBag.CategoriasAmenaza = new List<string> { "DESASTRES_NATURALES", "ORIGEN_INDUSTRIAL", "NO_INTENCIONADOS", "ATAQUES_INTENCIONADOS" };

            ViewBag.VulnerabilidadOptions = Enum.GetValues(typeof(Vulnerabilidades));
            ViewBag.ImpactoOptions = Enum.GetValues(typeof(TagImpacto));
            ViewBag.PosibilidadOptions = new List<int> { 1, 2, 3, 4, 5, 6, 7 };            
            List<SelectListItem> itemsDeActivos = ActivosController.listaDeActivos
                .Select(activo => new SelectListItem { Text = activo.Nombre, Value = activo.Id_Activo.ToString() })
                .ToList();

            // Pasar la lista de SelectListItem a SelectList
            ViewBag.ListaActivos = new SelectList(itemsDeActivos, "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Riesgo riesgo)
        {
            riesgo.Id_Riesgo = "R00" + idCounter;
            idCounter++;

            // Buscar el activo completo basado en el ID seleccionado
            var activoSeleccionado = ActivosController.listaDeActivos
                                      .FirstOrDefault(a => a.Id_Activo == riesgo.ActivoEnRiesgo.Id_Activo);

            // Asignar el objeto activo completo a ActivoEnRiesgo
            riesgo.ActivoEnRiesgo = activoSeleccionado;

            listaDeRiesgos.Add(riesgo);

            return RedirectToAction("Index");
        }

        // GET: RiesgosController/Details/5
        public ActionResult Details(string id)
        {
            var riesgo = listaDeRiesgos.FirstOrDefault(r => r.Id_Riesgo == id);
            if (riesgo == null)
            {
                return NotFound();
            }

            // Asegúrate de inicializar ViewBag.CategoriasAmenaza antes de pasar la vista.
            ViewBag.CategoriasAmenaza = new List<string> { "DESASTRES_NATURALES", "ORIGEN_INDUSTRIAL", "NO_INTENCIONADOS", "ATAQUES_INTENCIONADOS" };

            return View(riesgo);
        }

        // GET: RiesgosController/Edit/5
        public ActionResult Edit(string id)
        {
            // Buscar el riesgo en la lista por el id proporcionado
            Riesgo riesgo = listaDeRiesgos.FirstOrDefault(r => r.Id_Riesgo == id);

            if (riesgo == null)
            {
                // Si no se encuentra el riesgo, redirigir al listado de riesgos
                return RedirectToAction("Index");
            }

            // Preparar ViewBag para los dropdowns en la vista de edición
            ViewBag.CategoriasAmenaza = new List<string> { "DESASTRES_NATURALES", "ORIGEN_INDUSTRIAL", "NO_INTENCIONADOS", "ATAQUES_INTENCIONADOS" };
            ViewBag.VulnerabilidadOptions = Enum.GetValues(typeof(Vulnerabilidades));
            ViewBag.ImpactoOptions = Enum.GetValues(typeof(TagImpacto));
            ViewBag.PosibilidadOptions = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            List<SelectListItem> itemsDeActivos = ActivosController.listaDeActivos
                .Select(activo => new SelectListItem { Text = activo.Nombre, Value = activo.Id_Activo.ToString() })
                .ToList();
            ViewBag.ListaActivos = new SelectList(itemsDeActivos, "Value", "Text");

            return View(riesgo);
        }

        // POST: RiesgosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Riesgo riesgo)
        {
            if (ModelState.IsValid)
            {
                // Buscar el riesgo en la lista por el id proporcionado
                Riesgo riesgoExistente = listaDeRiesgos.FirstOrDefault(r => r.Id_Riesgo == riesgo.Id_Riesgo);

                if (riesgoExistente != null)
                {
                    // Aplicar las actualizaciones al riesgo existente
                    riesgoExistente.Nombre = riesgo.Nombre;
                    riesgoExistente.Descripcion = riesgo.Descripcion;
                    riesgoExistente.CategoriaAmenaza = riesgo.CategoriaAmenaza;
                    riesgoExistente.TagCategoria = riesgo.TagCategoria;
                    riesgoExistente.Vulnerabilidad = riesgo.Vulnerabilidad;
                    riesgoExistente.NivelAceptableDeRiesgo = riesgo.NivelAceptableDeRiesgo;
                    riesgoExistente.NivelDeRiesgo = riesgo.NivelDeRiesgo;
                    riesgoExistente.Impacto = riesgo.Impacto;
                    riesgoExistente.PosibilidadDeOcurrir = riesgo.PosibilidadDeOcurrir;
                    // Asignar el ActivoEnRiesgo buscándolo por el Id_Activo
                    riesgoExistente.ActivoEnRiesgo = ActivosController.listaDeActivos.FirstOrDefault(a => a.Id_Activo == riesgo.ActivoEnRiesgo.Id_Activo);

                    // Aquí deberías guardar los cambios en tu almacenamiento persistente (base de datos, etc.).
                    // ...

                    return RedirectToAction(nameof(Index));
                }
            }

            // Si llegamos aquí, algo salió mal, recargar la vista con el modelo riesgo
            // Preparar ViewBag para los dropdowns en la vista de edición
            ViewBag.CategoriasAmenaza = new List<string> { "DESASTRES_NATURALES", "ORIGEN_INDUSTRIAL", "NO_INTENCIONADOS", "ATAQUES_INTENCIONADOS" };
            ViewBag.VulnerabilidadOptions = Enum.GetValues(typeof(Vulnerabilidades));
            ViewBag.ImpactoOptions = Enum.GetValues(typeof(TagImpacto));
            ViewBag.PosibilidadOptions = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            List<SelectListItem> itemsDeActivos = ActivosController.listaDeActivos
                .Select(activo => new SelectListItem { Text = activo.Nombre, Value = activo.Id_Activo.ToString() })
                .ToList();
            ViewBag.ListaActivos = new SelectList(itemsDeActivos, "Value", "Text");

            return View(riesgo);
        }



        // GET: RiesgosController/Delete/5
        public ActionResult Delete(string id)
        {
            Riesgo riesgooEliminar = listaDeRiesgos.FirstOrDefault(a => a.Id_Riesgo == id.ToString());

            listaDeRiesgos.Remove(riesgooEliminar);
            return RedirectToAction(nameof(Index));
        }

        // POST: ActivosController/Delete/5
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
        
    }
}
