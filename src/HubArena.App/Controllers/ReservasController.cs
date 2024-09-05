//using AutoMapper;
//using HubArena.App.Data;
//using HubArena.App.ViewModels;
//using HubArena.Business.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HubArena.App.Controllers
//{
//    public class ReservasController : Controller
//    {
//        private readonly IReservaRepository _reservaRepository;
//        //Quadra
//        //Equipamento
//        private readonly IMapper _mapper;

//        public ReservasController(IReservaRepository reservaRepository, IMapper mapper)
//        {
//            _reservaRepository = reservaRepository;
//            _mapper = mapper;
//        }

//        // GET: Reservas
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.ReservaViewModel.ToListAsync());
//        }

//        // GET: Reservas/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reservaViewModel = await _context.ReservaViewModel
//                .FirstOrDefaultAsync(m => m.IdReserva == id);
//            if (reservaViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(reservaViewModel);
//        }

//        // GET: Reservas/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Reservas/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("IdReserva,Data,HorarioInicio,HorarioFim,StatusReserva,IdQuadra,IdFuncionario")] ReservaViewModel reservaViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(reservaViewModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(reservaViewModel);
//        }

//        // GET: Reservas/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reservaViewModel = await _context.ReservaViewModel.FindAsync(id);
//            if (reservaViewModel == null)
//            {
//                return NotFound();
//            }
//            return View(reservaViewModel);
//        }

//        // POST: Reservas/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,Data,HorarioInicio,HorarioFim,StatusReserva,IdQuadra,IdFuncionario")] ReservaViewModel reservaViewModel)
//        {
//            if (id != reservaViewModel.IdReserva)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(reservaViewModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ReservaViewModelExists(reservaViewModel.IdReserva))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(reservaViewModel);
//        }

//        // GET: Reservas/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reservaViewModel = await _context.ReservaViewModel
//                .FirstOrDefaultAsync(m => m.IdReserva == id);
//            if (reservaViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(reservaViewModel);
//        }

//        // POST: Reservas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var reservaViewModel = await _context.ReservaViewModel.FindAsync(id);
//            if (reservaViewModel != null)
//            {
//                _context.ReservaViewModel.Remove(reservaViewModel);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ReservaViewModelExists(int id)
//        {
//            return _context.ReservaViewModel.Any(e => e.IdReserva == id);
//        }
//    }
//}
