using AutoMapper;
using HubArena.App.ViewModels;
using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubArena.App.Controllers
{
    public class QuadrasController : Controller
    {
        private readonly IQuadraRepository _quadraRepository;
        private readonly IEsporteRepository _esporteRepository;
        private readonly IMapper _mapper;

        public QuadrasController(IQuadraRepository quadraRepository, IEsporteRepository esporteRepository, IMapper mapper)
        {
            _quadraRepository = quadraRepository;
            _esporteRepository = esporteRepository;
            _mapper = mapper;
        }

        // GET: Quadras
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<QuadraViewModel>>(await _quadraRepository.ObterQuadrasEsportes()));
        }

        // GET: Quadras/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var quadraViewModel = await ObterQuadra(id);
                
            if (quadraViewModel == null) return NotFound();

            return View(quadraViewModel);
        }

      

        // GET: Quadras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quadras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuadraViewModel quadraViewModel)
        {
            if (! ModelState.IsValid) return View(quadraViewModel);

            var quadra = _mapper.Map<QuadraModel>(quadraViewModel);

            await _quadraRepository.Add(quadra);

            return RedirectToAction("Index");

        }

        // GET: Quadras/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var quadraViewModel = await ObterQuadra(id);

            if (quadraViewModel == null) return NotFound();
  
            return View(quadraViewModel);
        }

        // POST: Quadras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QuadraViewModel quadraViewModel)
        {
            if (id != quadraViewModel.IdQuadra) return NotFound();

            var quadraAtualizacao = await PopularEsportes(quadraViewModel);

            quadraViewModel.Esporte = quadraAtualizacao.Esporte;

            if (!ModelState.IsValid) return View(quadraViewModel);

            quadraAtualizacao.Nome = quadraViewModel.Nome;
            quadraAtualizacao.Capacidade = quadraViewModel.Capacidade;
            quadraAtualizacao.TipoQuadra = quadraViewModel.TipoQuadra;
            quadraAtualizacao.StatusQuadra = quadraViewModel.StatusQuadra;
            //quadraAtualizacao.Endereco = quadraViewModel.Endereco;

            await _quadraRepository.Update(_mapper.Map<QuadraModel>(quadraAtualizacao));

            return RedirectToAction("Index");

        }

        
        // GET: Quadras/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var quadraViewModel = await ObterQuadra(id);
               
            if (quadraViewModel == null) return NotFound();

            return View(quadraViewModel);
        }

        // POST: Quadras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quadraViewModel = await ObterQuadra(id);

            if (quadraViewModel == null) return NotFound();

            var quadra = _mapper.Map<QuadraModel>(quadraViewModel);

            await _quadraRepository.Delete(quadra);

            return RedirectToAction("Index");
        }

        private async Task<QuadraViewModel> ObterQuadra(int id)
        {
            return _mapper.Map<QuadraViewModel>(_quadraRepository.ObterQuadraEsporte(id));
        }

        private async Task<QuadraViewModel> PopularEsportes(QuadraViewModel quadraViewModel)
        {
            quadraViewModel.Esportes = _mapper.Map<IEnumerable<EsporteViewModel>>(await _esporteRepository.GetAll());

            return quadraViewModel;
        }

    }
}
