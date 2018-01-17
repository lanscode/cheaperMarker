using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface LivraisonIdal:IDisposable
    {
        void add(Livraison Livraison);
        List<Livraison> findAll();
        Livraison find(int id);

    }
}
