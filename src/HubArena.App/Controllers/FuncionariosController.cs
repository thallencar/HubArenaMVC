using AutoMapper;
using HubArena.App.ViewModels;
using HubArena.Business.Enums;
using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubArena.App.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FuncionarioViewModel>>(await _funcionarioRepository.ObterFuncionariosEnderecos()));
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

            funcionarioViewModel.Endereco.TipoEndereco = (int)TipoEnderecoEnum.Funcionario;
            funcionarioViewModel.Endereco.IdQuadra = null;

            funcionarioViewModel.StatusPessoa = (int)StatusPessoaEnum.Ativo;

            await _funcionarioRepository.Add(_mapper.Map<FuncionarioModel>(funcionarioViewModel));

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

            await _funcionarioRepository.Update(_mapper.Map<FuncionarioModel>(funcionarioViewModel));

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

        public async Task<IActionResult> AtualizarEndereco(int id)
        {
            var funcionario = await ObterFuncionarioEndereco(id);

            if (funcionario == null) return NotFound();

            return PartialView("_EnderecoEdit", new FuncionarioViewModel { Endereco = funcionario.Endereco });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco (FuncionarioViewModel funcionarioViewModel)
        {
            //Ignora os campos obrigatórios da viewmodel
            ModelState.Remove("Nome");
            ModelState.Remove("Cargo");
            ModelState.Remove("Documento");
            ModelState.Remove("DataNascimento");
            ModelState.Remove("Email");
            ModelState.Remove("Usuario");
            ModelState.Remove("Senha");
            ModelState.Remove("StatusPessoa");

            if (!ModelState.IsValid) return PartialView("_EnderecoEdit", funcionarioViewModel.Endereco);

            await _enderecoRepository.Update(_mapper.Map<EnderecoModel>(funcionarioViewModel.Endereco));

            var url = Url.Action("ObterEndereco", "Funcionarios", new { id = funcionarioViewModel.Endereco.IdFuncionario });

            return Json(new { success = true, url });
        }

        private async Task<FuncionarioViewModel> ObterFuncionarioEndereco(int id)
        {
            return _mapper.Map<FuncionarioViewModel>(await _funcionarioRepository.ObterFuncionarioEndereco(id));
        }
    }
}