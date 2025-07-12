using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Actividad4Prog3.Models;


namespace Actividad4Prog3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly Actividades4Context _context;

        public CalificacionesController(Actividades4Context context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public async Task<IActionResult> Index()
        {
            var calificaciones = await _context.Calificaciones
                .Include(c => c.CodigoMateriaNavigation)
                .ToListAsync();

            return View(calificaciones);
        }


        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var calificacion = await _context.Calificaciones
                .Include(c => c.CodigoMateriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (calificacion == null)
                return NotFound();

            return View(calificacion);
        }

        // GET: Calificaciones/Create
        public IActionResult Create()
        {
            ViewData["CodigoMateria"] = new SelectList(_context.Materias, "Codigo", "Nombre");
            return View();
        }

        // POST: Calificaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatriculaEstudiante,CodigoMateria,Nota,Periodo")] Calificacione calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CodigoMateria"] = new SelectList(_context.Materias, "Codigo", "Nombre", calificacion.CodigoMateria);
            return View(calificacion);
        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null)
                return NotFound();

            ViewData["CodigoMateria"] = new SelectList(_context.Materias, "Codigo", "Nombre", calificacion.CodigoMateria);
            return View(calificacion);
        }

        // POST: Calificaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatriculaEstudiante,CodigoMateria,Nota,Periodo")] Calificacione calificacion)
        {
            if (id != calificacion.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacioneExists(calificacion.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CodigoMateria"] = new SelectList(_context.Materias, "Codigo", "Nombre", calificacion.CodigoMateria);
            return View(calificacion);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var calificacion = await _context.Calificaciones
                .Include(c => c.CodigoMateriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (calificacion == null)
                return NotFound();

            return View(calificacion);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion != null)
            {
                _context.Calificaciones.Remove(calificacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CalificacioneExists(int id)
        {
            return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}
