using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class Approvisionnement
    {
        [Key]
        public int id { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
        public virtual Produit Produit { get; set; }

        [Required(ErrorMessage ="Veillez saisir la quantité ")]
        public int quantite { get; set; }
    }
}