using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_Ex_3.Models;

namespace WebApp_Ex_3.Controllers
{
    public class FamiliaController : Controller
    {
        private readonly ApplicationContext _context;

        public FamiliaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Familia
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Familias.Include(f => f.condominio);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Familia/Create
        public IActionResult Create()
        {
            ViewData["Id_Condominio"] = new SelectList(_context.Condominios, "Id_Condominio", "Nome");
            return View();
        }

        // POST: Familia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Familia,Nome,Apto,Id_Condominio")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Condominio"] = new SelectList(_context.Condominios, "Id_Condominio", "Nome", familia.Id_Condominio);
            return View(familia);
        }

        // GET: Familia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familias.FindAsync(id);
            if (familia == null)
            {
                return NotFound();
            }
            ViewData["Id_Condominio"] = new SelectList(_context.Condominios, "Id_Condominio", "Nome", familia.Id_Condominio);
            return View(familia);
        }

        // POST: Familia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Familia,Nome,Apto,Id_Condominio")] Familia familia)
        {
            if (id != familia.Id_Familia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaExists(familia.Id_Familia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Condominio"] = new SelectList(_context.Condominios, "Id_Condominio", "Nome", familia.Id_Condominio);
            return View(familia);
        }

        // GET: Familia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var familia = await _context.Familias.FindAsync(id);

            _context.Familias.Remove(familia);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaExists(int id)
        {
            return _context.Familias.Any(e => e.Id_Familia == id);
        }
    }
}
