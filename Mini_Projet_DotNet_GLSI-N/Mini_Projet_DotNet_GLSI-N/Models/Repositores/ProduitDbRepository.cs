using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models.Repositores
{
    public class ProduitDbRepository : IProduitRepository<Produit>
    {
        Mini_Projet_DbContext db;

        public ProduitDbRepository(Mini_Projet_DbContext _db)

        {
           db = _db;
        }

        public void Add(Produit entity)
        {
           db.Produits.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var produits = Find(id);
            db.Produits.Remove(produits);
            db.SaveChanges();
        }

        public Produit Find(int id)
        {
            var produis = db.Produits.Include(a => a.Image).SingleOrDefault(p => p.Id == id);
            return produis;
        }

        public IList<Produit> List()
        {
            return db.Produits.Include(a =>a.Image).ToList();
        }

        public void Update(int id, Produit newProduit)
        {
            db.Update(newProduit);
            db.SaveChanges();
        }
    }
}
