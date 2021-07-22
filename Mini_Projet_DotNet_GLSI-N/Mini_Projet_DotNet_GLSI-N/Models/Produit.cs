using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models
{
    public class Produit
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("reference")]
        [StringLength(250)]
        public string Reference { get; set; }
        [Column("description")]
        [StringLength(250)]
        public string Description { get; set; }
        public Image Image { get; set; }
    }
}
