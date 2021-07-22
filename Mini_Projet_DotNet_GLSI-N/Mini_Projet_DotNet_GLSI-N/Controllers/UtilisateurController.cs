using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Projet_DotNet_GLSI_N.Models;
using Mini_Projet_DotNet_GLSI_N.Models.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly IProduitRepository<Utilisateur> utilisateurRepository;
        

        public UtilisateurController(IProduitRepository<Utilisateur> _utilisateurRepository)
        {
            this.utilisateurRepository = _utilisateurRepository;
            
        }
        // GET: ProduitController
        public ActionResult Index()
        {
            var utilisateurs = utilisateurRepository.List();
            return View(utilisateurs);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            var utilisateurs = utilisateurRepository.Find(id);
            return View(utilisateurs);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Utilisateur utilisateur)
        {
            try
            {
                utilisateurRepository.Add(utilisateur);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            var utilisateur = utilisateurRepository.Find(id);
            return View(utilisateur);
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Utilisateur utilisateur)
        {
            try
            {
                utilisateurRepository.Update(id, utilisateur);
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
            var produits = utilisateurRepository.Find(id);

            return View(produits);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id, Utilisateur utilisateur)
        {
            try
            {
                utilisateurRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
