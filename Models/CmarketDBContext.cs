using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class CmarketDBContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Approvisionnement> Approvisionnements { get; set; }
        public DbSet<UserInstance> UserClasses { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
    }
}
