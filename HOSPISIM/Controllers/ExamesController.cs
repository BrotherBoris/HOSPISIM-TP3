using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HOSPISIM.Data;
using HOSPISIM.Models;

namespace HOSPISIM.Controllers
{
    public class ExamesController : Controller
    {
        private readonly HospismDbContext _context;

        public ExamesController(HospismDbContext context)
        {
            _context = context;
        }

        // GET: Exames
        public async Task<IActionResult> Index()
        {
            var hospismDbContext = _context.Exame.Include(e => e.Atendimento);
            return View(await hospismDbContext.ToListAsync());
        }

        // GET: Exames/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exame
                .Include(e => e.Atendimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // GET: Exames/Create
        public IActionResult Create()
        {
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora");
            return View();
        }

        // POST: Exames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,DataDeSolicitacao,DataDeRealizacao,Resultado,AtendimentoId")] Exame exame)
        {
            if (ModelState.IsValid)
            {
                exame.Id = Guid.NewGuid();
                _context.Add(exame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora", exame.AtendimentoId);
            return View(exame);
        }

        // GET: Exames/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exame.FindAsync(id);
            if (exame == null)
            {
                return NotFound();
            }
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora", exame.AtendimentoId);
            return View(exame);
        }

        // POST: Exames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Tipo,DataDeSolicitacao,DataDeRealizacao,Resultado,AtendimentoId")] Exame exame)
        {
            if (id != exame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExameExists(exame.Id))
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
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora", exame.AtendimentoId);
            return View(exame);
        }

        // GET: Exames/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exame
                .Include(e => e.Atendimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // POST: Exames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exame = await _context.Exame.FindAsync(id);
            if (exame != null)
            {
                _context.Exame.Remove(exame);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExameExists(Guid id)
        {
            return _context.Exame.Any(e => e.Id == id);
        }
    }
}
