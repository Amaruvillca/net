using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrudProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrudProductos.Controllers
{

    public class AlmacenesController : Controller
    {
        protected readonly ContextDb _context;

        public AlmacenesController(ContextDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var almacenes = _context.Almacenes.ToList();
            return View(almacenes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
         [HttpPost]
        public IActionResult Delete(int id_almacen)
        {
            try
            {
                var almacen = _context.Almacenes.Find(id_almacen);
            if (almacen != null)
            {
                _context.Almacenes.Remove(almacen);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Almacén eliminado correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Almacén no encontrado.";
            }
            return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["ErrorMessage"] = "Error al eliminar el almacén. Asegúrese de que no haya movimientos asociados.";
                
                return RedirectToAction("Index");
            }
        }
    }
}