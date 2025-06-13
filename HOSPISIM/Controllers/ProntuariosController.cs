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
    public class ProntuariosController : Controller
    {
        private readonly HospismDbContext _context;

        public ProntuariosController(HospismDbContext context)
        {
            _context = context;
        }

        // GET: Prontuarios
        public async Task<IActionResult> Index()
        {
            var hospismDbContext = _context.Prontuario.Include(p => p.Paciente);
            return View(await hospismDbContext.ToListAsync());
        }

        // GET: Prontuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .Include(p => p.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // GET: Prontuarios/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto");
            return View();
        }

        // POST: Prontuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroDoProntuario,DataDeAbertura,ObservacoesGerais,PacienteId")] Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                prontuario.Id = Guid.NewGuid();

                // Auto-incrementar Número do Prontuário
                var maiorNumero = await _context.Prontuario
                    .MaxAsync(p => (int?)p.NumeroDoProntuario) ?? 0;

                prontuario.NumeroDoProntuario = maiorNumero + 1;

                _context.Add(prontuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", prontuario.PacienteId);
            return View(prontuario);
        }

        // GET: Prontuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", prontuario.PacienteId);
            return View(prontuario);
        }

        // POST: Prontuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NumeroDoProntuario,DataDeAbertura,ObservacoesGerais,PacienteId")] Prontuario prontuario)
        {
            if (id != prontuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prontuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProntuarioExists(prontuario.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", prontuario.PacienteId);
            return View(prontuario);
        }

        // GET: Prontuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .Include(p => p.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // POST: Prontuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario != null)
            {
                _context.Prontuario.Remove(prontuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProntuarioExists(Guid id)
        {
            return _context.Prontuario.Any(e => e.Id == id);
        }
    }
}
