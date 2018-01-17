using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class Commande
    {
        [Key]
        public int id { get; set; } 
        public DateTime dateC { get; set; }
        [Required(ErrorMessage ="Veillez saisir l'adresse de livraison")]
        public string adresse { get; set; }
        public string statut { get; set; }
        public double prix { get; set; }
        public virtual Produit Produit { get; set; }
        [Required(ErrorMessage ="Veillez saisir la quantité ")]
        public int quantite { get; set; }
        public virtual Client client { get; set; }
    }
}