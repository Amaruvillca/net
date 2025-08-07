using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudProductos.Models;

namespace CrudProductos.Controllers;

public class HomeController : Controller
{
    protected readonly ContextDb _context;

    public HomeController(ContextDb context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var productos = _context.Productos.ToList();
        return View(productos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
