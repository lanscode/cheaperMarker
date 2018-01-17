using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class Produit
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Le champ label est le nom du produit donc il doit être renseigné")]
        public string label { get; set; }
        [Required(ErrorMessage ="Donnez quelques informations sur le produit")]
        public string description { get; set;}
        [Required(ErrorMessage ="Vous devez preciser la categorie (pc,phone,watch) du produit")]
        public string categorie { get; set; }
        [Required(ErrorMessage ="Precisez le prix unitaire du produit")]
        public double prix { get; set; }
        [Required(ErrorMessage ="Saisissez la quantité")]
        public int quantite { get; set; }
    }
}