using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class Fournisseur
    {
        [Key]
       public int id { get; set; }
        public string code { get; set; }
        public string UserName { get; set; }

    }
}