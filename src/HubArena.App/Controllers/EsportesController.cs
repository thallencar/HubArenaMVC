using AutoMapper;
using HubArena.App.ViewModels;
using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubArena.App.Controllers
{
    public class EsportesController : Controller
    {
        private readonly IEsporteRepository _esporteRepository;
        private readonly IMapper _mapper;

        public EsportesController(IEsporteRepository esporteRepository, IMapper mapper)
        {
            _esporteRepository = esporteRepository;
            _mapper = mapper;
        }

        // GET: Esportes
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EsporteViewModel>>(await _esporteRepository.GetAll()));
        }

        // GET: Esportes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var esporteViewModel = await ObterEsporte(id);

            if (esporteViewModel == null) return NotFound();

            return View(esporteViewModel);
        }


        // GET: Esportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Esportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EsporteViewModel esporteViewModel)
        {
            if (!ModelState.IsValid) return View(esporteViewModel);

            await _esporteRepository.Add(_mapper.Map<EsporteModel>(esporteViewModel));

            return RedirectToAction("Index");

        }

        // GET: Esportes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var esporteViewModel = await ObterEsporte(id);

            if (esporteViewModel == null) return NotFound();

            return View(esporteViewModel);
        }

        // POST: Esportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EsporteViewModel esporteViewModel)
        {
            if (id != esporteViewModel.IdEsporte) return NotFound();

            if (!ModelState.IsValid) return View(esporteViewModel);

            var esporte = _mapper.Map<EsporteModel>(esporteViewModel);

            await _esporteRepository.Update(esporte);

            return RedirectToAction("Index");
        }

        // GET: Esportes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var esporteViewModel = await ObterEsporte(id);

            if (esporteViewModel == null) return NotFound();

            return View(esporteViewModel);

        }

        // POST: Esportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var esporteViewModel = await ObterEsporte(id);

            if (esporteViewModel == null) return NotFound();

            await _esporteRepository.Delete(_mapper.Map<EsporteModel>(esporteViewModel));

            return RedirectToAction("Index");
        }

        private async Task<EsporteViewModel> ObterEsporte(int id)
        {
            return _mapper.Map<EsporteViewModel>(await _esporteRepository.ObterEsporte(id));
        }
    }
}
