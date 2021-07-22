using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models.Repositores
{
    public class UtilisateurDbRepository : IProduitRepository<Utilisateur>
    {
        Mini_Projet_DbContext db;
        public UtilisateurDbRepository(Mini_Projet_DbContext _db)
        {
            db = _db;
        }
        public void Add(Utilisateur entity)
        {
            db.Utilisateurs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var utilisateur = Find(id);
            db.Utilisateurs.Remove(utilisateur);
            db.SaveChanges();
        }

        public Utilisateur Find(int id)
        {
            var produis = db.Utilisateurs.SingleOrDefault(p => p.id == id);
            return produis;
        }

        public IList<Utilisateur> List()
        {
            return db.Utilisateurs.ToList();
        }

        public void Update(int id, Utilisateur newUtilisateur)
        {
            db.Update(newUtilisateur);
            db.SaveChanges();
        }
    }
}
