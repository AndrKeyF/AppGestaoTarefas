using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas.Models;
using Microsoft.AspNetCore.Authorization;

namespace GestaoTarefas.Controllers
{
    [Authorize(Policy = "CanManageGestaoTarefas")]
    public class DepartamentosController : Controller
    {
        private readonly GestaoTarefasDbContext _context;

        public DepartamentosController(GestaoTarefasDbContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ServicosSortParm"] = String.IsNullOrEmpty(sortOrder) ? "servico_desc" : "servico";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;

            }
            ViewData["CurrentFilter"] = searchString;

            var departamentos = from d in _context.Departamento.Include(d => d.Servico)
                               select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                departamentos = departamentos.Where(d => d.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    departamentos = departamentos.OrderByDescending(d => d.Nome);
                    break;
                case "servico_desc":
                    departamentos = departamentos.OrderByDescending(d => d.Servico);
                    break;
                case "servico":
                    departamentos = departamentos.OrderBy(d => d.Servico);
                    break;

                default:
                    departamentos = departamentos.OrderBy(d => d.Nome);
                    break;
            }

            /*int CARG_PER_PAGE = 3;
            int NUMBER_PAGES_BEFORE_AND_AFTER=1;

            return View(await PaginationVMCargo<Cargo>.CreateAsync(cargos.AsNoTracking(), pageNumber ?? 1, CARG_PER_PAGE, NUMBER_PAGES_BEFORE_AND_AFTER));
            */

            int pageSize = 5;
            return View(await PaginatedList<Departamento>.CreateAsync(departamentos.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .Include(d => d.Servico)
                .FirstOrDefaultAsync(m => m.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            ViewData["ServicoId"] = new SelectList(_context.Servico, "ServicoId", "ServicoId");
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartamentoId,Nome,ServicoId")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return View("Note", departamento);
            }
            ViewData["ServicoId"] = new SelectList(_context.Servico, "ServicoId", "ServicoId", departamento.ServicoId);
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            ViewData["ServicoId"] = new SelectList(_context.Servico, "ServicoId", "ServicoId", departamento.ServicoId);
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartamentoId,Nome,ServicoId")] Departamento departamento)
        {
            if (id != departamento.DepartamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.DepartamentoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return View("NoteE", departamento);
            }
            ViewData["ServicoId"] = new SelectList(_context.Servico, "ServicoId", "ServicoId", departamento.ServicoId);
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .Include(d => d.Servico)
                .FirstOrDefaultAsync(m => m.DepartamentoId == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);
            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return View("NoteD", departamento);
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.DepartamentoId == id);
        }
    }
}
