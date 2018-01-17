using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface CommandeIdal:IDisposable
    {
        void add(Commande com);
        Commande find(int id);
        List<Commande> findAll();
        List<Commande> findByStatus(string statut);
        void edit(Commande commande);
        List<Commande> findByClient(Client Client);

    }
}
