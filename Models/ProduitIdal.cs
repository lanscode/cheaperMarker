using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface ProduitIdal:IDisposable
    {
        
        void add(Produit Produit);
        void edit(Produit p,int q);
        Produit find(int id);
        Produit find(int? id);
        void delete(Produit p);
        List<Produit> findAll();
        List<Produit> findByCategorie(string categorie);
        Produit findByLabel(string label);
        Boolean exist(string label);
        
    }
}
