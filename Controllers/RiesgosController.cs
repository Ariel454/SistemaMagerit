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
