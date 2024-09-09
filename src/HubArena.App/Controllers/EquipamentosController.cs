using AutoMapper;
using HubArena.App.ViewModels;
using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubArena.App.Controllers
{
    public class EquipamentosController : Controller
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IEsporteRepository _esporteRepository;
        private readonly IMapper _mapper;

        public EquipamentosController(IEquipamentoRepository equipamentoRepository, IEsporteRepository esporteRepository ,IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _esporteRepository = esporteRepository;
            _mapper = mapper;
        }

        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EquipamentoViewModel>>(await _equipamentoRepository.ObterEquipamentosEsportes()));
        }

        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var equipamentoViewModel = await ObterEquipamento(id);

            if (equipamentoViewModel == null) return NotFound();

            return View(equipamentoViewModel);
        }

        // GET: Equipamentos/Create
        public async Task<IActionResult> Create()
        {
            var equipamentoViewModel = await PopularEsportes(new EquipamentoViewModel());
            return View(equipamentoViewModel);
        }

        // POST: Equipamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipamentoViewModel equipamentoViewModel)
        {
            if (!ModelState.IsValid) return View(equipamentoViewModel);

            await _equipamentoRepository.Add(_mapper.Map<EquipamentoModel>(equipamentoViewModel));

            return RedirectToAction("Index");

        }

        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var equipamentoViewModel = await ObterEquipamento(id);

            equipamentoViewModel = await PopularEsportes(equipamentoViewModel);

            if (equipamentoViewModel == null) return NotFound();

            return View(equipamentoViewModel);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EquipamentoViewModel equipamentoViewModel)
        {
            if (id != equipamentoViewModel.IdEquipamento) return NotFound();

            var equipamentoAtualizacao = await ObterEquipamento(id);

            equipamentoAtualizacao = await PopularEsportes(equipamentoViewModel);

            equipamentoViewModel.Esporte = equipamentoAtualizacao.Esporte;

            if (! ModelState.IsValid) return View(equipamentoViewModel);

            equipamentoAtualizacao.Nome = equipamentoViewModel.Nome;
            equipamentoAtualizacao.StatusEquipamento = equipamentoViewModel.StatusEquipamento;

            await _equipamentoRepository.Update(_mapper.Map<EquipamentoModel>(equipamentoAtualizacao));

            return RedirectToAction("Index");
        }

        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var equipamentoViewModel = await ObterEquipamento(id);

            if (equipamentoViewModel == null) return NotFound();

            return View(equipamentoViewModel);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipamentoViewModel = await ObterEquipamento(id);

            if (equipamentoViewModel == null) return NotFound();

            await _equipamentoRepository.Delete(_mapper.Map<EquipamentoModel>(equipamentoViewModel));

            return RedirectToAction("Index");
        }

        private async Task<EquipamentoViewModel> ObterEquipamento(int id)
        {
            return _mapper.Map<EquipamentoViewModel>(await _equipamentoRepository.ObterEquipamento(id));
        }

        private async Task<EquipamentoViewModel> PopularEsportes(EquipamentoViewModel equipamentoViewModel)
        {
            equipamentoViewModel.Esportes = _mapper.Map<IEnumerable<EsporteViewModel>>(await _esporteRepository.GetAll());

            return equipamentoViewModel;
        }
    }
}
