using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheaperMarket.Models;

namespace CheaperMarket.Models
{
    public class ApprovisionnementDal : ApprovisionnementIdal
    {
        private CmarketDBContext context;
        public ApprovisionnementDal()
        {
            context = new CmarketDBContext();
        }
        public void add(Approvisionnement approvisionnement)
        {
            context.Approvisionnements.Add(approvisionnement);
            context.SaveChanges();
        }

        public List<Approvisionnement> findAll()
        {
            return context.Approvisionnements.ToList();
        }

        public List<Approvisionnement> findByFournisseur(Fournisseur fournisseur)
        {

            List<Approvisionnement> approvisionnements = (from A in context.Approvisionnements
                                                         where A.Fournisseur == fournisseur select A).ToList();
            return approvisionnements;
    
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}