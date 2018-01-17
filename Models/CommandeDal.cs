using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CheaperMarket.Models;

namespace CheaperMarket.Models
{
    public class CommandeDal :CommandeIdal
    {
        private CmarketDBContext context;
        public CommandeDal()
        {
            context = new CmarketDBContext();
        }

        public void add(Commande com)
        {
            context.Commandes.Add(com);
            context.SaveChanges();
        }

       

        public Commande find(int id)
        {
            return context.Commandes.Find(id);
        }

        public List<Commande> findAll()
        {
            return context.Commandes.ToList();
        }

        public List<Commande>findByStatus(string statut)
        {
            List<Commande> com = context.Commandes.ToList();
            List<Commande> commandes = new List<Commande>();
            foreach (var cm in com)
            {
                if (cm.statut == statut)
                {
                    commandes.Add(cm);
                }
            }
            return commandes;
        }

        public List<Commande> findByClient(Client client)
        {
            List<Commande> commandes = (from c in context.Commandes
                                      where c.client.code == client.code
                                      select c).ToList();
            
            return commandes;
        }
        public void edit(Commande commande)
        {
            context.Entry(commande).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }


    }
}