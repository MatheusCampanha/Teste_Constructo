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
    public class CondominioController : Controller
    {
        private readonly ApplicationContext _context;

        public CondominioController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Condominio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Condominios.ToListAsync());
        }

        // GET: Condominio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Condominio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Condominio,Nome,Bairro")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condominio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condominio);
        }

        // GET: Condominio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominios.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }
            return View(condominio);
        }

        // POST: Condominio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Condominio,Nome,Bairro")] Condominio condominio)
        {
            if (id != condominio.Id_Condominio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condominio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondominioExists(condominio.Id_Condominio))
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
            return View(condominio);
        }

        // GET: Condominio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var condominio = await _context.Condominios.FindAsync(id);

            _context.Condominios.Remove(condominio);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CondominioExists(int id)
        {
            return _context.Condominios.Any(e => e.Id_Condominio == id);
        }
    }
}
