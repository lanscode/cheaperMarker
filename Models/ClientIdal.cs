using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface ClientIdal:IDisposable
    {
        void add(Client CLient);
        Client find(int id);
     
        Client findByCode(string Code);

    }
}
