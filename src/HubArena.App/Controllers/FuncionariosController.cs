using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HubArena.App.Data;
using HubArena.App.ViewModels;

namespace HubArena.App.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuncionarioViewModel.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarioViewModel = await _context.FuncionarioViewModel
                .FirstOrDefaultAsync(m => m.IdFuncionario == id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }

            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFuncionario,Nome,Cargo,Documento,DataNascimento,Sexo,Email,Usuario,Senha,StatusPessoa")] FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarioViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarioViewModel = await _context.FuncionarioViewModel.FindAsync(id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }
            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFuncionario,Nome,Cargo,Documento,DataNascimento,Sexo,Email,Usuario,Senha,StatusPessoa")] FuncionarioViewModel funcionarioViewModel)
        {
            if (id != funcionarioViewModel.IdFuncionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionarioViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioViewModelExists(funcionarioViewModel.IdFuncionario))
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
            return View(funcionarioViewModel);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarioViewModel = await _context.FuncionarioViewModel
                .FirstOrDefaultAsync(m => m.IdFuncionario == id);
            if (funcionarioViewModel == null)
            {
                return NotFound();
            }

            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarioViewModel = await _context.FuncionarioViewModel.FindAsync(id);
            if (funcionarioViewModel != null)
            {
                _context.FuncionarioViewModel.Remove(funcionarioViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioViewModelExists(int id)
        {
            return _context.FuncionarioViewModel.Any(e => e.IdFuncionario == id);
        }
    }
}
