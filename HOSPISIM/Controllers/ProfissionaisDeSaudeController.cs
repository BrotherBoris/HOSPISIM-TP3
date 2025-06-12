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
    public class ProfissionaisDeSaudeController : Controller
    {
        private readonly HospismDbContext _context;

        public ProfissionaisDeSaudeController(HospismDbContext context)
        {
            _context = context;
        }

        // GET: ProfissionaisDeSaude
        public async Task<IActionResult> Index()
        {
            var hospismDbContext = _context.ProfissionaisDeSaude.Include(p => p.Especialidade);
            return View(await hospismDbContext.ToListAsync());
        }

        // GET: ProfissionaisDeSaude/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalDeSaude = await _context.ProfissionaisDeSaude
                .Include(p => p.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionalDeSaude == null)
            {
                return NotFound();
            }

            return View(profissionalDeSaude);
        }

        // GET: ProfissionaisDeSaude/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome");
            return View();
        }

        // POST: ProfissionaisDeSaude/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,CPF,Email,Telefone,RegistroConselho,TipoRegistro,DataAdmissao,CargaHorariaSemanal,Turno,Ativo,EspecialidadeId")] ProfissionalDeSaude profissionalDeSaude)
        {
            if (ModelState.IsValid)
            {
                profissionalDeSaude.Id = Guid.NewGuid();
                _context.Add(profissionalDeSaude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalDeSaude.EspecialidadeId);
            return View(profissionalDeSaude);
        }

        // GET: ProfissionaisDeSaude/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalDeSaude = await _context.ProfissionaisDeSaude.FindAsync(id);
            if (profissionalDeSaude == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalDeSaude.EspecialidadeId);
            return View(profissionalDeSaude);
        }

        // POST: ProfissionaisDeSaude/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NomeCompleto,CPF,Email,Telefone,RegistroConselho,TipoRegistro,DataAdmissao,CargaHorariaSemanal,Turno,Ativo,EspecialidadeId")] ProfissionalDeSaude profissionalDeSaude)
        {
            if (id != profissionalDeSaude.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionalDeSaude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalDeSaudeExists(profissionalDeSaude.Id))
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
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalDeSaude.EspecialidadeId);
            return View(profissionalDeSaude);
        }

        // GET: ProfissionaisDeSaude/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissionalDeSaude = await _context.ProfissionaisDeSaude
                .Include(p => p.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionalDeSaude == null)
            {
                return NotFound();
            }

            return View(profissionalDeSaude);
        }

        // POST: ProfissionaisDeSaude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profissionalDeSaude = await _context.ProfissionaisDeSaude.FindAsync(id);
            if (profissionalDeSaude != null)
            {
                _context.ProfissionaisDeSaude.Remove(profissionalDeSaude);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalDeSaudeExists(Guid id)
        {
            return _context.ProfissionaisDeSaude.Any(e => e.Id == id);
        }
    }
}
