using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class Livraison
    {
        [Key]
        public int id { get; set; }
        public virtual Agent Agent{get;set;}
        public virtual Commande Commande { get; set; }
    }
}