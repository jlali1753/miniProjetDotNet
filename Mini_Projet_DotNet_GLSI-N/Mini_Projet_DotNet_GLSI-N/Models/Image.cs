using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Projet_DotNet_GLSI_N.Models
{
    public class Image
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nom")]
        [StringLength(250)]
        public string Nom { get; set; }
        [Column("chemin")]
        [StringLength(250)]
        public string Chemin { get; set; }
    }
}
