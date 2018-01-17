using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheaperMarket.Models;

namespace CheaperMarket.Models
{
    public class ClientDal : ClientIdal
    {
        private CmarketDBContext context;
        public ClientDal()
        {
            context = new CmarketDBContext();
        }
        public void add(Client Client)
        {
            context.Clients.Add(Client);
            context.SaveChanges();
        }

        public Client find(int id)
        {
            return context.Clients.Find(id);
        }
      
      
        public Client findByCode(string code)
        {
            return context.Clients.FirstOrDefault(client => client.code == code);
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}