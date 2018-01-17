using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheaperMarket.Models
{
    interface UserIdal:IDisposable
    {
        void add(UserInstance us);
        UserInstance findByUserName(string userName);
    }
}
