using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheaperMarket.Models;

namespace CheaperMarket.Models
{
    public class UserDal : UserIdal
    {
        private CmarketDBContext context;
        public UserDal()
        {
            context = new CmarketDBContext();
        }
        public void add(UserInstance us)
        {
            context.UserClasses.Add(us);
            context.SaveChanges();
        }
        public UserInstance findByUserName(string userName)
        {
            UserInstance uc = context.UserClasses.FirstOrDefault(u=>u.UserName==userName);
            return uc;
           
        }
      
        public void Dispose()
        {
            context.Dispose();
        }

       
    }
}