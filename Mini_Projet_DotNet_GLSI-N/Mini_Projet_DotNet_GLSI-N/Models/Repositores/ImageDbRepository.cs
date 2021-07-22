using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models.Repositores
{
    public class ImageDbRepository : IProduitRepository<Image>
    {
        Mini_Projet_DbContext db;
        public ImageDbRepository(Mini_Projet_DbContext _db)
        {
            db = _db;
        }
        public void Add(Image entity)
        {
            db.Images.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var image = Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
        }

        public Image Find(int id)
        {
            var images = db.Images.SingleOrDefault(p => p.Id == id);
            return images;
        }

        public IList<Image> List()
        {
            return db.Images.ToList();
        }

        public void Update(int id, Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
