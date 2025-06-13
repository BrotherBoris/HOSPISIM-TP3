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
    public class AtendimentosController : Controller
    {
        private readonly HospismDbContext _context;

        public AtendimentosController(HospismDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<JsonResult> GetProntuariosPorPaciente(Guid pacienteId)
        {
            var prontuarios = await _context.Prontuario
                .Where(p => p.PacienteId == pacienteId)
                .Select(p => new
                {
                    value = p.Id,
                    text = p.NumeroDoProntuario + $" - {p.DataDeAbertura:dd/MM/yyyy} - " + (p.ObservacoesGerais.Length > 20 ? p.ObservacoesGerais.Substring(0, 50) + "..." : p.ObservacoesGerais)
                })
                .ToListAsync();

            return Json(prontuarios);
        }



        // GET: Atendimentos
        public async Task<IActionResult> Index()
        {
            var hospismDbContext = _context.Atendimento.Include(a => a.Paciente).Include(a => a.ProfissionalDeSaude).Include(a => a.Prontuario);
            return View(await hospismDbContext.ToListAsync());
        }

        // GET: Atendimentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.Paciente)
                .Include(a => a.ProfissionalDeSaude)
                .Include(a => a.Prontuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentos/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto");
            ViewData["ProfissionalDeSaudeId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto");
            ViewData["ProntuarioId"] = new SelectList(_context.Set<Prontuario>(), "Id", "ObservacoesGerais");
            return View();
        }

        // POST: Atendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEHora,Tipo,Status,Local,ProntuarioId,PacienteId,ProfissionalDeSaudeId")] Atendimento atendimento)
        {
            // Verificação de integridade
            var prontuario = await _context.Prontuario
                .FirstOrDefaultAsync(p => p.Id == atendimento.ProntuarioId);

            if (prontuario == null || prontuario.PacienteId != atendimento.PacienteId)
            {
                ModelState.AddModelError("ProntuarioId", "O prontuário selecionado não pertence ao paciente.");
            }


            if (ModelState.IsValid)
            {
                atendimento.Id = Guid.NewGuid();
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", atendimento.PacienteId);
            ViewData["ProfissionalDeSaudeId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto", atendimento.ProfissionalDeSaudeId);

            // Repopular prontuários do paciente atual para manter consistência
            var prontuariosPaciente = await _context.Prontuario
                .Where(p => p.PacienteId == atendimento.PacienteId)
                .Select(p => new
                {
                    p.Id,
                    Descricao = $"{p.DataDeAbertura:dd/MM/yyyy} - {(p.ObservacoesGerais.Length > 20 ? p.ObservacoesGerais.Substring(0, 20) + "..." : p.ObservacoesGerais)}"
                })
                .ToListAsync();

            ViewData["ProntuarioId"] = new SelectList(_context.Set<Prontuario>(), "Id", "ObservacoesGerais", atendimento.ProntuarioId);
            
            
            return View(atendimento);
        }

        // GET: Atendimentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", atendimento.PacienteId);
            ViewData["ProfissionalDeSaudeId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto", atendimento.ProfissionalDeSaudeId);
            ViewData["ProntuarioId"] = new SelectList(_context.Set<Prontuario>(), "Id", "ObservacoesGerais", atendimento.ProntuarioId);
            return View(atendimento);
        }

        // POST: Atendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DataEHora,Tipo,Status,Local,ProntuarioId,PacienteId,ProfissionalDeSaudeId")] Atendimento atendimento)
        {
            if (id != atendimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", atendimento.PacienteId);
            ViewData["ProfissionalDeSaudeId"] = new SelectList(_context.ProfissionaisDeSaude, "Id", "NomeCompleto", atendimento.ProfissionalDeSaudeId);
            ViewData["ProntuarioId"] = new SelectList(_context.Set<Prontuario>(), "Id", "ObservacoesGerais", atendimento.ProntuarioId);
            return View(atendimento);
        }

        // GET: Atendimentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.Paciente)
                .Include(a => a.ProfissionalDeSaude)
                .Include(a => a.Prontuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimento.Remove(atendimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(Guid id)
        {
            return _context.Atendimento.Any(e => e.Id == id);
        }
    }
}
