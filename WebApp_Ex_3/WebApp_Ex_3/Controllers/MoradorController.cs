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
    public class MoradorController : Controller
    {
        private readonly ApplicationContext _context;

        public MoradorController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Morador
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Moradors.Include(m => m.familia);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Morador/Create
        public IActionResult Create()
        {
            ViewData["Id_Familia"] = new SelectList(_context.Familias, "Id_Familia", "Nome");
            return View();
        }

        // POST: Morador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Morador,Nome,QtdBichos,Id_Familia")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(morador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Familia"] = new SelectList(_context.Familias, "Id_Familia", "Nome", morador.Id_Familia);
            return View(morador);
        }

        // GET: Morador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Moradors.FindAsync(id);
            if (morador == null)
            {
                return NotFound();
            }
            ViewData["Id_Familia"] = new SelectList(_context.Familias, "Id_Familia", "Nome", morador.Id_Familia);
            return View(morador);
        }

        // POST: Morador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Morador,Nome,QtdBichos,Id_Familia")] Morador morador)
        {
            if (id != morador.Id_Morador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(morador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradorExists(morador.Id_Morador))
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
            ViewData["Id_Familia"] = new SelectList(_context.Familias, "Id_Familia", "Nome", morador.Id_Familia);
            return View(morador);
        }

        // GET: Morador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var morador = await _context.Moradors.FindAsync(id);

            _context.Moradors.Remove(morador);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MoradorExists(int id)
        {
            return _context.Moradors.Any(e => e.Id_Morador == id);
        }
    }
}
