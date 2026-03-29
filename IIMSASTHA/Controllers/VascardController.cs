using IIMSASTHA.Data;
using IIMSASTHA.Interfaces;
using IIMSASTHA.Models;
using Microsoft.AspNetCore.Mvc;

namespace IIMSASTHA.Controllers
{
    public class VascardController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly Ivascard _ivascard;

        public VascardController(ApplicationDbContext ctx, Ivascard ivascard)
        {
           _context = ctx;
           _ivascard = ivascard;
        }

        public IActionResult Index()
        {
            List<Vascard> vcrd = _ivascard.GetAllVascard();
            return View(vcrd);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vascard vcrd)
        {
            try
            {
                _ivascard.AddVascard(vcrd);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(actionName:nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vscrd = _ivascard.GetVascardById(id);
            return View(vscrd);
        }
        [HttpPost]
        public IActionResult Edit(Vascard vcrd)
        {
            _ivascard.UpdateVascard(vcrd);
            _context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var vscrd = _ivascard.GetVascardById(id);
            return View(vscrd);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var vscrd = _context.vascards.Find(id);
            return View(vscrd);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _ivascard.DeleteVascard(id);
            _context.SaveChanges(true);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
