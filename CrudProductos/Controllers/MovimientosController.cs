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
    
    public class MovimientosController : Controller
    {
        protected readonly ContextDb _context;
        public MovimientosController(ContextDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movimientos = _context.MovimientosStock.Include(m => m.Producto).Include(m => m.Almacen).ToList();
            return View(movimientos);
        }
        [HttpPost]
        public IActionResult Delete(int id_movimiento)
        {
            var movimiento = _context.MovimientosStock.Find(id_movimiento);
            if (movimiento != null)
            {
                _context.MovimientosStock.Remove(movimiento);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Movimiento eliminado correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Movimiento no encontrado.";
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}