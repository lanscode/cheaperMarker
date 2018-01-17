using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class LivraisonViewModel
    {
        public List<Commande> CommandesLivrees { get; set; }
        public List<Commande> CommandesEnCours { get; set; }
    }
}