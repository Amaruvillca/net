using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrudProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrudProductos.Controllers
{

    public class ProductosController : Controller
    {
        protected readonly ContextDb _context;

        public ProductosController(ContextDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var productos = _context.Productos.Include(p => p.Categoria).ToList();
            return View(productos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
         [HttpPost]
        public IActionResult Delete(int id_producto)
        {
            try
            {
                var producto = _context.Productos.Find(id_producto);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Producto eliminado correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Producto no encontrado.";
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