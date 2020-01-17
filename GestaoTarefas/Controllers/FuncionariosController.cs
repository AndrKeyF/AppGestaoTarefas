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
    //[Authorize(Roles = "andr, cris,tig ")]
    public class FuncionariosController : Controller
    {

/*
        private int NUMBER_PAGES_BEFORE_AND_AFTER = 2;
        private decimal NUMBER_FUNC_PER_PAGE = 5;
        private int FUNC_PER_PAGE = 5;

*/
        private readonly GestaoTarefasDbContext _context;

        public FuncionariosController(GestaoTarefasDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        /*      public async Task<IActionResult> Index(int page = 1)
              {
                  decimal numberFuncionarios = _context.Funcionario.Count();
                  PaginationVMFunc vm = new PaginationVMFunc
                  {
                      Funcionarios = _context.Funcionario.OrderBy(p => p.Nome).Skip((page - 1) * FUNC_PER_PAGE).Take(FUNC_PER_PAGE).Include(f => f.Cargo),
                      CurrentPage = page,
                      FirstPageShow = Math.Max(1, page - NUMBER_PAGES_BEFORE_AND_AFTER),
                      TotalPages = (int)Math.Ceiling(numberFuncionarios / NUMBER_FUNC_PER_PAGE)
                  };
                  vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_PAGES_BEFORE_AND_AFTER);
                  return View(vm);
              }

      */

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome desc" : "";
            ViewData["CCSortParm"] = String.IsNullOrEmpty(sortOrder) ? "CC" : "CC desc";
            ViewData["TeleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Telemovel" : "Telemovel desc";
            ViewData["EmailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Email" : "Email desc";
            ViewData["CargoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "CargoNome" : "CargoNome desc";
            ViewData["DepartamentoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "DepNome" : "DepNome desc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var funcionarios = from f in _context.Funcionario.Include(f => f.Cargo).Include( f => f.Departamento)
                               select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                funcionarios = funcionarios.Where(f => f.Nome.Contains(searchString)
                                       || f.Telemovel.Contains(searchString)
                                       || f.CC.Contains(searchString)
                                       || f.Email.Contains(searchString)
                                       || f.Cargo.Nome.Contains(searchString)
                                       || f.Departamento.Nome.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nome desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Nome);
                    break;
                case "CC":
                    funcionarios = funcionarios.OrderBy(f => f.CC);
                    break;
                case "CC desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.CC);
                    break;
                case "Telemovel":
                    funcionarios = funcionarios.OrderBy(f => f.Telemovel);
                    break;
                case "Telemovel desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Telemovel);
                    break;
                case "Email":
                    funcionarios = funcionarios.OrderBy(f => f.Email);
                    break;
                case "Email desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Email);
                    break;
                case "CargoNome":
                    funcionarios = funcionarios.OrderBy(s => s.Cargo.Nome);
                    break;
                case "CargoNome desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Cargo.Nome);
                    break;
                case "DepNome":
                    funcionarios = funcionarios.OrderBy(f => f.Departamento.Nome);
                    break;
                case "DepNome desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Departamento.Nome);
                    break;
                default:
                    funcionarios = funcionarios.OrderBy(f => f.Nome);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Funcionario>.CreateAsync(funcionarios.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Cargo)
                .Include(s => s.Departamento)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo.OrderBy(c => c.Nome), "CargoId", "Nome");
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento.OrderBy(d => d.Nome), "DepartamentoId", "Nome");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,Telemovel,CC,Email,CargoId,DepartamentoId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return View("Note", funcionario);
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo.OrderBy(c => c.Nome), "CargoId", "Nome", funcionario.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento.OrderBy(d => d.Nome), "DepartamentoId", "Nome", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo.OrderBy(c => c.Nome), "CargoId", "Nome", funcionario.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento.OrderBy(d => d.Nome), "DepartamentoId", "Nome", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,Telemovel,CC,Email,CargoId,DepartamentoId")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return View("NoteE", funcionario);
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo.OrderBy(c => c.Nome), "CargoId", "Nome", funcionario.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento.OrderBy(d => d.Nome), "DepartamentoId", "Nome", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Cargo)
                .Include(s => s.Departamento)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return View("NoteD", funcionario);
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.FuncionarioId == id);
        }
    }
}
