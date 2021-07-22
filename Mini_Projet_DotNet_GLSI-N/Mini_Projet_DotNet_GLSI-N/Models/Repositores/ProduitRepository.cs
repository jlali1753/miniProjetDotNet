using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models.Repositores
{
    public class ProduitRepository : IProduitRepository<Produit>
    {
        List<Produit> produit;

        public ProduitRepository()
        {
            produit = new List<Produit>()
            {
                new Produit
                {
                    Id =1 , Reference="RF001", Description="Produit 2019", Image = new Image()
                },
                 new Produit
                {
                    Id=2 , Reference="RF002", Description="Produit 2020",Image = new Image()
                },
                  new Produit
                {
                    Id=3 , Reference="RF003", Description="Produit 2021",Image = new Image()
                },

            };
        }

        public void Add(Produit entity)
        {
            entity.Id = produit.Max(b => b.Id) + 1;
            produit.Add(entity);
        }

        public void Delete(int id)
        {
            var produits = produit.SingleOrDefault(p => p.Id == id);
            produit.Remove(produits);
        }

        public Produit Find(int id)
        {
            var produis = produit.SingleOrDefault(p => p.Id == id);
            return produis;
        }

        public IList<Produit> List()
        {
            return produit;
        }

        public void Update(int id, Produit newProduit)
        {
            var produits = produit.SingleOrDefault(p => p.Id == id);


            produits.Reference = newProduit.Reference;
            produits.Description = newProduit.Description;
            produits.Image = newProduit.Image;
        }
    }
}
