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
    public class CategoriasController : Controller
    {
        protected readonly ContextDb _context;

        public CategoriasController(ContextDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        [HttpPost]
        public IActionResult Delete(int id_categoria)
        {
            try
            {
                var categoria = _context.Categorias.Find(id_categoria);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Categoría eliminada correctamente.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Categoría no encontrada.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["ErrorMessage"] = "Error al eliminar la categoría. Asegúrese de que no haya productos asociados.";

                return RedirectToAction("Index");
            }
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Categorias categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Categoría creada correctamente.";
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
    }
}