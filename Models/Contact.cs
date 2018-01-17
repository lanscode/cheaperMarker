using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public virtual Fournisseur Fournisseur{ get; set; }
        [Required(ErrorMessage ="Veillez preciser l'objet du message")]
        public string objet { get; set; }
        [Required(ErrorMessage ="Vous devez saisir le message à envoyer")]
        public string message { get; set; }
        //l'attribut type permet de savoir si le fournisseur est l'emetteur(from) ou recepteur 
        //et si celui-ci est recepteur(to) cela signifie que l'admin est l'emetteur
        public string type { get; set; }
    }
}