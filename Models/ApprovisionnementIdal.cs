using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface ApprovisionnementIdal:IDisposable
    {
        void add(Approvisionnement approvisionnement);
        List<Approvisionnement> findAll();
        List<Approvisionnement> findByFournisseur(Fournisseur Fournisseur);
    }
}
