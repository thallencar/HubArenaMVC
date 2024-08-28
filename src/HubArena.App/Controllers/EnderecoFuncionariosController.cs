using AutoMapper;
using HubArena.App.ViewModels;
using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubArena.App.Controllers
{
    public class EnderecoFuncionariosController : Controller
    {
        private readonly IEnderecoFuncionarioRepository _enderecoFuncionarioRepository;
        private readonly IMapper _mapper;

        public EnderecoFuncionariosController(IEnderecoFuncionarioRepository enderecoFuncionarioRepository, IMapper mapper)
        {
            _enderecoFuncionarioRepository = enderecoFuncionarioRepository;
            _mapper = mapper;
        }

        // GET: EnderecoFuncionarios
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EnderecoFuncionarioViewModel>>(await _enderecoFuncionarioRepository.GetAll()));
        }

        // GET: EnderecoFuncionarios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var enderecoFuncionarioViewModel = await ObterEnderecoFuncionario(id);

            if (enderecoFuncionarioViewModel == null) return NotFound();

            return View(enderecoFuncionarioViewModel);
        }

       

        // GET: EnderecoFuncionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnderecoFuncionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnderecoFuncionarioViewModel enderecoFuncionarioViewModel)
        {
            if (!ModelState.IsValid) return View(enderecoFuncionarioViewModel);
                
            await _enderecoFuncionarioRepository.Add(_mapper.Map<EnderecoFuncionarioModel>(enderecoFuncionarioViewModel));
           
            return RedirectToAction("Index");
        }

        // GET: EnderecoFuncionarios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var enderecoFuncionarioViewModel = await ObterEnderecoFuncionario(id);

            if (enderecoFuncionarioViewModel == null) return NotFound();

            return View(enderecoFuncionarioViewModel);
        }

        // POST: EnderecoFuncionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EnderecoFuncionarioViewModel enderecoFuncionarioViewModel)
        {
            if (id != enderecoFuncionarioViewModel.IdEnderecoFuncionario) return NotFound();
          
            if (!ModelState.IsValid) return View(enderecoFuncionarioViewModel);

            var enderecoFuncionario = _mapper.Map<EnderecoFuncionarioModel>(enderecoFuncionarioViewModel);

            await _enderecoFuncionarioRepository.Update(enderecoFuncionario);
               
            return RedirectToAction("Index");
        }

    

        // GET: EnderecoFuncionarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var enderecoFuncionarioViewModel = await ObterEnderecoFuncionario(id);

            if (enderecoFuncionarioViewModel == null) return NotFound();
            
            return View(enderecoFuncionarioViewModel);
        }

        // POST: EnderecoFuncionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enderecoFuncionarioViewModel = await ObterEnderecoFuncionario(id);

            if (enderecoFuncionarioViewModel == null) return NotFound();
            
            await _enderecoFuncionarioRepository.Delete(_mapper.Map<EnderecoFuncionarioModel>(enderecoFuncionarioViewModel));
            
            return RedirectToAction("Index");
        }

        private async Task<EnderecoFuncionarioViewModel> ObterEnderecoFuncionario(int id)
        {
            return _mapper.Map<EnderecoFuncionarioViewModel>(await _enderecoFuncionarioRepository.ObterEnderecoFuncionario(id));
        }
    }
}

