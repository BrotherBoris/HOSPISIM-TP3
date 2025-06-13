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
    public class PrescricoesController : Controller
    {
        private readonly HospismDbContext _context;

        public PrescricoesController(HospismDbContext context)
        {
            _context = context;
        }

        // GET: Prescricoes
        public async Task<IActionResult> Index()
        {
            var hospismDbContext = _context.Prescricoes.Include(p => p.Atendimento).Include(p => p.Profissional);
            return View(await hospismDbContext.ToListAsync());
        }

        // GET: Prescricoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricoes
                .Include(p => p.Atendimento)
                .Include(p => p.Profissional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescricao == null)
            {
                return NotFound();
            }

            return View(prescricao);
        }

        // GET: Prescricoes/Create
        public IActionResult Create()
        {
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora");
            ViewData["ProfissionalId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto");
            return View();
        }

        // POST: Prescricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Medicamento,Dosagem,Frequencia,ViaAdministracao,DataInicio,DataFim,Observacoes,StatusPrescricao,ReacoesAdversas,AtendimentoId,ProfissionalId")] Prescricao prescricao)
        {
            if (ModelState.IsValid)
            {
                prescricao.Id = Guid.NewGuid();
                _context.Add(prescricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora", prescricao.AtendimentoId);
            ViewData["ProfissionalId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto", prescricao.ProfissionalId);
            return View(prescricao);
        }

        // GET: Prescricoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricoes.FindAsync(id);
            if (prescricao == null)
            {
                return NotFound();
            }
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora", prescricao.AtendimentoId);
            ViewData["ProfissionalId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto", prescricao.ProfissionalId);
            return View(prescricao);
        }

        // POST: Prescricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Medicamento,Dosagem,Frequencia,ViaAdministracao,DataInicio,DataFim,Observacoes,StatusPrescricao,ReacoesAdversas,AtendimentoId,ProfissionalId")] Prescricao prescricao)
        {
            if (id != prescricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescricaoExists(prescricao.Id))
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
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimento, "Id", "DataEHora", prescricao.AtendimentoId);
            ViewData["ProfissionalId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto", prescricao.ProfissionalId);
            return View(prescricao);
        }

        // GET: Prescricoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricao = await _context.Prescricoes
                .Include(p => p.Atendimento)
                .Include(p => p.Profissional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescricao == null)
            {
                return NotFound();
            }

            return View(prescricao);
        }

        // POST: Prescricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prescricao = await _context.Prescricoes.FindAsync(id);
            if (prescricao != null)
            {
                _context.Prescricoes.Remove(prescricao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescricaoExists(Guid id)
        {
            return _context.Prescricoes.Any(e => e.Id == id);
        }
    }
}
