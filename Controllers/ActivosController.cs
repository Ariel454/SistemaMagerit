using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeguridadInformática.Enums;
using SeguridadInformática.Models;
using System;
using System.Diagnostics.Metrics;

namespace SistemaMagerit.Controllers
{
    public class ActivosController : Controller
    {

        // Lista estática para almacenar los activos
        public static List<Activo> listaDeActivos = new List<Activo>();
        public static int idCounter = 1;

        // GET: ActivosController
        public ActionResult Index()
        {
            // Pasa la lista de activos como modelo
            return View("Views/Activos/Index.cshtml", listaDeActivos);
        }


        // GET: ActivosController/Create
        public IActionResult Create()
        {
            // Preparar datos para los ComboBox
            ViewBag.TipoActivoOptions = Enum.GetValues(typeof(TipoDeActivo));
            ViewBag.TagActivoOptions = Enum.GetValues(typeof(TagsType));
            ViewBag.ValoracionCortaOptions = Enum.GetValues(typeof(ValoracionCorta));
            ViewBag.ValoracionIntegridadOptions = Enum.GetValues(typeof(ValoracionIntegridad));
            ViewBag.ValoracionLargaOptions = Enum.GetValues(typeof(ValoracionLarga));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Activo activo)
        {
            // Asignar el nuevo ID al activo
            activo.Id_Activo = "A00" + idCounter;

            // Incrementar el contador para la próxima vez
            idCounter++;

            // Agregar el nuevo activo a la lista
            listaDeActivos.Add(activo);

            // Agrega el mensaje a TempData
            TempData["Message"] = "Se ha creado un activo.";

            // Redirigir a la acción Index
            return RedirectToAction("Index");
        }



        // GET: ActivosController/Details/5
        public ActionResult Details(string id)
        {
            Activo activoDetalle = listaDeActivos.FirstOrDefault(a => a.Id_Activo == id.ToString());
            ViewBag.TagActivoOptions = Enum.GetValues(typeof(TagsType));

            switch (activoDetalle.TipoTag.ToString())
            {
                case "Software":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagSoftware));
                    break;
                case "Servicios":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagServicios));
                    break;
                case "Instalaciones":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagInstalaciones));
                    break;
                case "Equipamiento_Auxiliar":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagEquipamientoAuxiliar));
                    break;
                case "Equipos_Informaticos":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagEquiposInformaticos));
                    break;
                case "Redes_De_Comunicaciones":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagRedesDeComunicaciones));
                    break;
                case "Personal":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagPersonal));
                    break;
                    // Agrega más casos según sea necesario
            }

            return View(activoDetalle);
        }


        // GET: ActivosController/Edit/5
        public ActionResult Edit(string id)
        {
            // Buscar el activo en la lista por el id proporcionado
            Activo activo = listaDeActivos.FirstOrDefault(a => a.Id_Activo == id.ToString());

            if (activo == null)
            {
                // Si no se encuentra el activo, puedes manejarlo según tus necesidades (por ejemplo, mostrar un mensaje de error).
                return RedirectToAction("Index");
            }

            ViewBag.TagActivoOptions = Enum.GetValues(typeof(TagsType));

            switch (activo.TipoTag.ToString())
            {
                case "Software":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagSoftware));
                    break;
                case "Servicios":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagServicios));
                    break;
                case "Instalaciones":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagInstalaciones));
                    break;
                case "Equipamiento_Auxiliar":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagEquipamientoAuxiliar));
                    break;
                case "Equipos_Informaticos":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagEquiposInformaticos));
                    break;
                case "Redes_De_Comunicaciones":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagRedesDeComunicaciones));
                    break;
                case "Personal":
                    ViewBag.TipoTagOptions = Enum.GetValues(typeof(TagPersonal));
                    break;
                    // Agrega más casos según sea necesario
            }

            return View(activo);
        }

        // POST: ActivosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activo activo)
        {
            if (ModelState.IsValid)
            {
                // Buscar el activo en la lista por el id proporcionado
                Activo activoExistente = listaDeActivos.FirstOrDefault(a => a.Id_Activo == activo.Id_Activo);

                if (activoExistente != null)
                {
                    // Aplicar las actualizaciones al activo existente
                    activoExistente.Nombre = activo.Nombre;
                    activoExistente.TipoActivo = activo.TipoActivo;
                    activoExistente.TipoTag = activo.TipoTag;
                    activoExistente.TagActivo = activo.TagActivo;
                    activoExistente.Confidencialidad = activo.Confidencialidad;
                    activoExistente.Integridad = activo.Integridad;
                    activoExistente.Disponibilidad = activo.Disponibilidad;
                    // Actualiza otros atributos según sea necesario

                    // Aquí deberías guardar los cambios en tu almacenamiento persistente (base de datos, etc.).
                    // ...

                    return RedirectToAction(nameof(Index));
                }
            }

            // Si llegamos aquí, algo salió mal, vuelve a cargar la vista con el modelo activo
            return View(activo);
        }



        // GET: ActivosController/Delete/5
        public ActionResult Delete(string id)
        {
            Activo activoEliminar = listaDeActivos.FirstOrDefault(a => a.Id_Activo == id.ToString());

            listaDeActivos.Remove(activoEliminar);
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
