using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface FournisseurIdal:IDisposable
    {
        void add(Fournisseur Fournisseur);
        Fournisseur find(int id);
        List<Fournisseur> findAll();
        Fournisseur findByCode(string code);
    }
}
