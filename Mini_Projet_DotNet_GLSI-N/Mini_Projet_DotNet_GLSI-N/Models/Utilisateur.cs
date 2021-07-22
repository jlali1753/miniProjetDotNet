using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models
{
    public class Utilisateur
    {
        public int id { get; set; }
        public string email { get; set; }
        public string motdepasse { get; set; }
        public string role { get; set; }

    }
}
