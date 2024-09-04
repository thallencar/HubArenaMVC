using AutoMapper;
using HubArena.App.ViewModels;
using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubArena.App.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FuncionarioViewModel>>(await _funcionarioRepository.GetAll()));
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var funcionarioViewModel = await ObterFuncionarioEndereco(id);

            if (funcionarioViewModel == null) return NotFound();

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
        public async Task<IActionResult> Create(FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid) return View(funcionarioViewModel);

            var funcionario = _mapper.Map<FuncionarioModel>(funcionarioViewModel);

            await _funcionarioRepository.Add(funcionario);

            return RedirectToAction("Index");
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var funcionarioViewModel = await ObterFuncionarioEndereco(id);

            if (funcionarioViewModel == null) return NotFound();

            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FuncionarioViewModel funcionarioViewModel)
        {
            if (id != funcionarioViewModel.IdFuncionario) return NotFound();

            if (!ModelState.IsValid) return View(funcionarioViewModel);

            var funcionario = _mapper.Map<FuncionarioModel>(funcionarioViewModel);

            await _funcionarioRepository.Update(funcionario);

            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var funcionarioViewModel = await ObterFuncionarioEndereco(id);

            if (funcionarioViewModel == null) return NotFound();

            return View(funcionarioViewModel);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarioViewModel = await ObterFuncionarioEndereco(id);

            if (funcionarioViewModel == null) return NotFound();

            await _funcionarioRepository.Delete(_mapper.Map<FuncionarioModel>(funcionarioViewModel));
            return RedirectToAction("Index");
        }

        private async Task<FuncionarioViewModel> ObterFuncionarioEndereco(int id)
        {
            return _mapper.Map<FuncionarioViewModel>(await _funcionarioRepository.ObterFuncionarioEndereco(id));
        }
    }
}