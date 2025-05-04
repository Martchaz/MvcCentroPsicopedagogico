using Microsoft.AspNetCore.Mvc;
using MvcCentroPsicopedagogico.Data;
using MvcCentroPsicopedagogico.Models.Usuarios;
using System.Linq;

public class UsuarioController : Controller
{
    private readonly MvcCentroPsicopedagogicoContext _context;

    public UsuarioController(MvcCentroPsicopedagogicoContext context)
    {
        _context = context;
    }

    // GET: Usuario
    public IActionResult Index()
    {
        return View(_context.Usuario.ToList());
    }

    // GET: Usuario/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Usuario/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("User,Password")] Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(usuario);
    }

    // GET: Usuario/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var usuario = _context.Usuario.Find(id);
        if (usuario == null)
            return NotFound();

        return View(usuario);
    }

    // POST: Usuario/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,User,Password")] Usuario usuario)
    {
        if (id != usuario.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(usuario);
    }

    // GET: Usuario/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var usuario = _context.Usuario.Find(id);
        if (usuario == null)
            return NotFound();

        return View(usuario);
    }

    // POST: Usuario/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var usuario = _context.Usuario.Find(id);
        _context.Usuario.Remove(usuario);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
