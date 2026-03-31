using IIMSASTHA.Data;
using IIMSASTHA.Interfaces;
using IIMSASTHA.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace IIMSASTHA.Controllers
{
    public class VascardController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly Ivascard _ivascard;

        private readonly IWebHostEnvironment _env; 

        public VascardController(ApplicationDbContext ctx, Ivascard ivascard, IWebHostEnvironment env)
        {
           _context = ctx;
           _ivascard = ivascard;
           _env = env;
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
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Vascard vcrd,IFormFile ImageFile,IFormFile SignatureFile)
        {
            if (ImageFile != null)
            {
                
                string fileName = Path.GetFileName(ImageFile.FileName);
                string filePath = Path.Combine("wwwroot/Vascard", fileName);
                

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                vcrd.ImageUrl = "/Vascard/" + fileName;     
            }
            else
            {
                vcrd.ImageUrl = "default.jpg"; 
            }

            if (SignatureFile != null)
            {

                string fileName = Path.GetFileName(SignatureFile.FileName);
                string filePath = Path.Combine("wwwroot/Vascard", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SignatureFile.CopyToAsync(stream);
                }

                vcrd.SigImageUrl = "/Vascard/" + fileName;  
            }
            else
            {
                vcrd.SigImageUrl = "default.jpg"; 
            }
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
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(Vascard vcrd,IFormFile ImageFile, IFormFile SignatureFile)
        {

            if (ImageFile != null)
            {
                string fileName = Path.GetFileName(ImageFile.FileName);
                string filePath = Path.Combine("wwwroot/Vascard", fileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                vcrd.ImageUrl = "/Vascard/" + fileName;

            }
            else
            {
                vcrd.ImageUrl = "default.jpg";
            }

            if (SignatureFile != null)
            {

                string fileName = Path.GetFileName(SignatureFile.FileName);
                string filePath = Path.Combine("wwwroot/Vascard", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SignatureFile.CopyToAsync(stream);
                }

                vcrd.SigImageUrl = "/Vascard/" + fileName;
            }
            else
            {
                vcrd.SigImageUrl = "default.jpg";
            }

            try
            {
                _ivascard.UpdateVascard(vcrd);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            
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

        private string UplodedFile(Vascard vcrd) 
        {
            string uniqueFileName = null;

            if (vcrd.ImageUrl !=null)
            {

                string uploadsFolder = Path.Combine(_env.WebRootPath,"images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + vcrd.ImageUrl;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + vcrd.SigImageUrl;
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filepath, FileMode.Create)) 
                {
                   
                }
            }
            return uniqueFileName;
        }
    }
}
