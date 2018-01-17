using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheaperMarket.Models;

namespace CheaperMarket.Models
{
    public class LivariasonDAl : LivraisonIdal
    {
        private CmarketDBContext context;
        public LivariasonDAl()
        {
            context = new CmarketDBContext();
        }
        public void add(Livraison livraison)
        {
            context.Livraisons.Add(livraison);
            context.SaveChanges();
            this.Dispose();
        }

        public Livraison find(int id)
        {
            return context.Livraisons.Find(id);
        }

        public List<Livraison> findAll()
        {
           return context.Livraisons.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}