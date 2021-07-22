using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models.Repositores
{
    public class ImageRepository : IProduitRepository<Image>
    {
        List<Image> image;
        public ImageRepository()
        {
            image = new List<Image>()
            {
                new Image
                {
                    Id =1 , Nom="RF001", Chemin="Produit 2019",
                },
                new Image
                {
                    Id =2 , Nom="RF002", Chemin="Produit 2020",
                },
                new Image
                {
                    Id =3 , Nom="RF003", Chemin="Produit 2021",
                },


            };
        }
        public void Add(Image entity)
        {
            entity.Id = image.Max(b => b.Id) + 1;
            image.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Image Find(int id)
        {
            var images = image.SingleOrDefault(p => p.Id == id);
            return images;
        }

        public IList<Image> List()
        {
            return image;
        }

        public void Update(int id, Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
