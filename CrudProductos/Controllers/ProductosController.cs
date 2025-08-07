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
    
    public class ProductosController : Controller
    {
       protected readonly ContextDb _context;

        public ProductosController(ContextDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        
        {
            var productos = _context.Productos.ToList();
        return View(productos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}