using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class ProduitViewModel
    {
        public List<Produit> Pcs { get; set;}
        public List<Produit> Watchs { get; set;}
        public List<Produit> Choes { get; set;}
        public List<Produit> phones { get; set; }   
        public Produit Produit { get; set; }
        public UserInstance user { get; set; }
        
    }
}