using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class AgentDal : AgentIdal
    {
        private CmarketDBContext context;
        public AgentDal()
        {
            context = new CmarketDBContext();
        }
        public void create(Agent agent)
        {
            context.Agents.Add(agent);
            context.SaveChanges();
        }

        public Agent find(int id)
        {
            return context.Agents.Find(id);
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public Agent findByCode(string code)
        {
            Agent agent=context.Agents.FirstOrDefault(a=>a.code==code);
            return agent;
        }

       
    }
}