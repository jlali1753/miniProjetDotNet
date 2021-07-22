using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Projet_DotNet_GLSI_N.Models;
using Mini_Projet_DotNet_GLSI_N.Models.Repositores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Controllers
{
    public class ImageController : Controller
    {
        private readonly Mini_Projet_DbContext _adb;
        private readonly IWebHostEnvironment _iwebhost;
        private readonly IProduitRepository<Image> imageRepository;
        public ImageController(Mini_Projet_DbContext adb, IWebHostEnvironment iwebhost, IProduitRepository<Image> imageRepository)
        {
            _adb = adb;
            _iwebhost = iwebhost;
            this.imageRepository = imageRepository;
        }
        public IActionResult Index()
        {
            // return View();
            var result = _adb.Images.ToList();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile ifile, Image imgc)
        {
            string imgext = Path.GetExtension(ifile.FileName);
            if (imgext == ".jpg")
            {
                var saveimage = Path.Combine(_iwebhost.WebRootPath, "Uploads", ifile.FileName);
                var streem = new FileStream(saveimage, FileMode.CreateNew);
                await ifile.CopyToAsync(streem);
                imgc.Nom = ifile.FileName;
                imgc.Chemin = saveimage;
                await _adb.Images.AddAsync(imgc);
                await _adb.SaveChangesAsync();
                ViewBag.Message = "Le fichier sélectionne est sauvegardé dans un dossier Uploads et le chemin dans la BD";

            }
            else
            {
                ViewBag.Message = "sélectionne une image JPEG";

            }
             //return View();

            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var images = imageRepository.Find(id);
            return View(images);
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            var image = imageRepository.Find(id);

            return View(image);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id, Image images)
        {
            try
            {
                imageRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
