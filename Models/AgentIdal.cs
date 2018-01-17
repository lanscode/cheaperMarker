using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface AgentIdal:IDisposable
    {
        void create(Agent agent);
        Agent find(int id);
        Agent findByCode(string code);

    }
}
