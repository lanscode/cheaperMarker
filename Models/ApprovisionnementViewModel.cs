using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class ApprovisionnementViewModel
    {
        public List<Produit> Pcs { get; set; }
        public List<Produit> Phones { get; set; }
        public List<Produit> Watchs { get; set; }
        public string quantite { get; set; }
        public List<Approvisionnement> Approvisionnements { get; set; }
        public UserInstance user { get; set; }

    }
}