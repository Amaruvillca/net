using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrudProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Create()
{
    ViewBag.Categorias = new SelectList(_context.Categorias, "id_categoria", "nombre_categoria");
    return View();
}
        [HttpPost]
        public IActionResult Create(Productos producto, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                // Validar extensión
                var extension = Path.GetExtension(imagen.FileName).ToLower();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("imagen", "Tipo de archivo no permitido.");
                    return View(producto);
                }

                // Generar nombre único
                var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");

                // Asegurarse que el directorio existe
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var filePath = Path.Combine(folderPath, uniqueFileName);

                // Guardar el archivo
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen.CopyTo(fileStream);
                }

                // Guardar el nombre en el modelo (ej. para mostrarlo luego)
                producto.imagen = uniqueFileName;
            }

            // Validación del modelo y persistencia
            if (ModelState.IsValid)
            {
                producto.fecha_registro = DateTime.Now;
                _context.Productos.Add(producto);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Producto creado correctamente.";
                return RedirectToAction("Index");
            }

            return View(producto);
        }
        [HttpGet]
        [Route("Productos/Edit/{id_producto}")]
        public IActionResult Edit(int id_producto)
        {
            var producto = _context.Productos.Include(p => p.Categoria).FirstOrDefault(p => p.id_producto == id_producto);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "id_categoria", "nombre_categoria", producto.id_categoria);
            return View(producto);
        }

        [HttpPost]
        [Route("Productos/Edit/{id_producto}")]
        public IActionResult Edit(Productos producto, IFormFile imagen)
        {
            if (ModelState.IsValid)
            {
                if (imagen != null && imagen.Length > 0)
                {
                    // Validar extensión
                    var extension = Path.GetExtension(imagen.FileName).ToLower();
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("imagen", "Tipo de archivo no permitido.");
                        return View(producto);
                    }

                    // Generar nombre único
                    var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");

                    // Asegurarse que el directorio existe
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var filePath = Path.Combine(folderPath, uniqueFileName);

                    // Guardar el archivo
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imagen.CopyTo(fileStream);
                    }

                    // Guardar el nombre en el modelo (ej. para mostrarlo luego)
                    producto.imagen = uniqueFileName;
                }
                producto.fecha_registro = DateTime.Now;

                _context.Productos.Update(producto);
                _context.SaveChanges();
producto.fecha_registro = DateTime.Now;
                TempData["SuccessMessage"] = "Producto actualizado correctamente.";
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "id_categoria", "nombre_categoria", producto.id_categoria);
            return View(producto);
        }

    }
}