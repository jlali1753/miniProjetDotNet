using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models
{
    public class Mini_Projet_DbContext : DbContext
    {
        public Mini_Projet_DbContext(DbContextOptions<Mini_Projet_DbContext> options):base(options)
        {

        }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}
