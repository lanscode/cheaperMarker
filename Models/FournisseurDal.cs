using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheaperMarket.Models;

namespace CheaperMarket.Models
{
    public class FournisseurDal : FournisseurIdal
    {
        private CmarketDBContext context;
        public FournisseurDal()
        {
            context = new CmarketDBContext();
        }
        public void add(Fournisseur Fournisseur)
        {
           context.Fournisseurs.Add(Fournisseur);
            context.SaveChanges();
        }

       

        public Fournisseur find(int id)
        {            
            return context.Fournisseurs.Find(id);
        }

        public Fournisseur findByCode(string code)
        {
            Fournisseur fournisseur = context.Fournisseurs.FirstOrDefault(f => f.code == code);
            return fournisseur;
        }

        public List<Fournisseur> findAll()
        {
            return context.Fournisseurs.ToList();
        }
        public void Dispose()
        {
            context.Dispose();
        }

        
    }
}