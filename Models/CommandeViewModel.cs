using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class CommandeViewModel
    {
        public List<Commande> CommandeByClient { get; set; }
        public List<Commande> AllCommandes { get; set; }
        public List<Commande> CommandesLivrees { get; set; }
        public List<Commande> CommandesEnCours { get; set; }
        public UserInstance user { get; set; }
        public string adresse { get; set; }
        public int quantite { get; set; }
    }
}