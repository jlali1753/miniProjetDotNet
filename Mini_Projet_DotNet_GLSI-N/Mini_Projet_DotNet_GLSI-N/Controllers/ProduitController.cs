using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Projet_DotNet_GLSI_N.Models;
using Mini_Projet_DotNet_GLSI_N.Models.Repositores;
using Mini_Projet_DotNet_GLSI_N.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitRepository<Produit> produitRepository;
        private readonly IProduitRepository<Image> imageRepository;

       
        public ProduitController(IProduitRepository<Produit> produitRepository, IProduitRepository<Image> imageRepository)
        {
            this.produitRepository = produitRepository;
            this.imageRepository = imageRepository;
        }
        // GET: ProduitController
        public ActionResult Index()
        {
            var produits = produitRepository.List();
            return View(produits);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            var produits = produitRepository.Find(id);
            return View(produits);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            var model = new ProduitImageViewModels
            {
                Images = FillSelectList()
            };  
            return View(model);
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProduitImageViewModels model)
        {
            if(ModelState.IsValid )
            {
                try
                {
                    if (model.ImageId == -1)
                    {
                        ViewBag.Message = "veuillez sélectionner une image dans la liste !";
                        var vmodel = new ProduitImageViewModels
                        {
                            Images = FillSelectList()
                        };
                        return View(vmodel);
                    }
                    Produit produit = new Produit
                    {
                        Id = model.ProduitId,
                        Reference = model.Reference,
                        Description = model.Description,
                        Image = imageRepository.Find(model.ImageId)

                    };
                    produitRepository.Add(produit);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
                
            }
            ModelState.AddModelError("", "vous devez remplir tous les champs obligatoires !");
            return View();

        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            var produit = produitRepository.Find(id);
           // var imageId = produit.Image == null ? produit.Image.Id = 0 : produit.Image.Id;
            var viewModel = new ProduitImageViewModels
            {
                ProduitId = produit.Id,
                Reference = produit.Reference,
                Description = produit.Description,
                ImageId = produit.Image == null ? produit.Image.Id = 0 : produit.Image.Id,
                Images = imageRepository.List().ToList()
            };
            return View(viewModel);
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProduitImageViewModels model)
        {
            try
            {
                Produit produit = new Produit
                {
                    Reference = model.Reference,
                    Description = model.Description,
                    Image = imageRepository.Find(model.ImageId)

                };
                produitRepository.Update( model.ProduitId,produit);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            var produit = produitRepository.Find(id);
            
            return View(produit);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)

        {
            try
            {
                produitRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Image> FillSelectList()
        {
            var images = imageRepository.List().ToList();
            images.Insert(0, new Image { Id = -1, Nom = "  --- Veuillez sélectionner une Image" });
            return images;
        }
    }
}
