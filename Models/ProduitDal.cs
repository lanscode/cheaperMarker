using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CheaperMarket.Models;
using MoreLinq;

namespace CheaperMarket.Models
{
    public class ProduitDal : ProduitIdal
    {
        private CmarketDBContext context;
        public ProduitDal()
        {
            context = new CmarketDBContext();
        }
        public void add(Produit Produit)
        {
            context.Produits.Add(Produit);
            context.SaveChanges();
        }

       

        public Produit find(int?id)
        {
            return context.Produits.Find(id);
        }

        public List<Produit> findAll()
        {
            return context.Produits.ToList();
        }

        public Produit findByLabel(string label)
        {
            return context.Produits.FirstOrDefault(p => p.label == label);
        }
        public Boolean exist(string label)
        {
            Boolean valid = false;
            List<Produit> ps = context.Produits.ToList();
            foreach(var item in ps)
            {
                if (item.label == label)
                    valid = true;
            }
            return valid;
        }
        public List<Produit> findByCategorie(string categorie)
        {

            List<Produit> produits = (from p in context.Produits
                                      where p.categorie == categorie select p).ToList();
            List<Produit>ps=produits
                                .GroupBy(p=>p.label)
                                .Select(p=>p.First()).ToList();
          

             return ps;
            //return context.Produits.SqlQuery("SELECT * FROM Produits WHERE categorie = @p0",categorie).ToList();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public void delete(Produit p)
        {
            context.Produits.Remove(p);
            context.SaveChanges();
        }
      

        public void edit(Produit p ,int q)
        {
            p.quantite = q;
            if (p != null)
            {

                //context.Produits.Attach(p);
                context.Entry(p).Property(x => x.quantite).IsModified = true;
                context.Entry(p).State = EntityState.Modified;
                context.SaveChanges();
            }
            
        }

        public Produit find(int id)
        {
            return context.Produits.Find(id);
        }
    }
}