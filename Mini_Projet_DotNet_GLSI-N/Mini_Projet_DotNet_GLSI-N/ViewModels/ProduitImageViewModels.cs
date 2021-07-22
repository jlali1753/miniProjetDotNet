using Mini_Projet_DotNet_GLSI_N.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.ViewModels
{
    public class ProduitImageViewModels
    {

        public int ProduitId { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Reference { get; set; }

        [Required]
        [MaxLength(150)]
        [MinLength(5)]
        public string Description { get; set; }
        public int ImageId { get; set; }
        public List<Image> Images { get; set; }
    }
}
