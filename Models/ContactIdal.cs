using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface ContactIdal:IDisposable
    {
        void create(Contact contact);
        List<Contact> findAll();
        List<Contact> findByFournisseur(Fournisseur fournisseur);
    }
}
