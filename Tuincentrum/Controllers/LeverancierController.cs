using Microsoft.AspNetCore.Mvc;
using Tuincentrum.Models;
using Microsoft.EntityFrameworkCore;

namespace Tuincentrum.Controllers
{
    public class LeverancierController : Controller
    {
        private readonly  ILeveranciersRepository leveranciersRepository;
        private readonly MvctuinCentrumContext _context;
        public LeverancierController(ILeveranciersRepository leveranciersRepository, MvctuinCentrumContext _context)
        {
            this.leveranciersRepository = leveranciersRepository;
            this._context = _context;

        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Leveranciers.ToListAsync());
        }   
    }
}
