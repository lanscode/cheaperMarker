using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class UserInstance
    {
        [Key]
        public int id { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
    }
}