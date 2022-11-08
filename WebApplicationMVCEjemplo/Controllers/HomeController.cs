using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationMVCEjemplo.DataEF;
using WebApplicationMVCEjemplo.Models;

namespace WebApplicationMVCEjemplo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context; 

        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;


        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null) return NotFound();
            var usuario = _context.Usuario.Find(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null) return NotFound();
            var usuario = _context.Usuario.Find(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (usuario == null) return View("Error");
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se creó correctamente";

                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (usuario == null) return View("Error");
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se modificó correctamente";

                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrar(Usuario usuario)
        {
            if (usuario == null) return View("Error");
            if (ModelState.IsValid)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se eliminó correctamente";
                return RedirectToAction("Index");

            }
            return View();
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
}