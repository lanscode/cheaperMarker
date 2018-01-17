using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class ContactViewModel
    {
        public Contact contact { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Fournisseur> Fournisseurs { get; set; }
        public UserInstance UserInstance { get; set; }
    }
}