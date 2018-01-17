using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheaperMarket.Models;

namespace CheaperMarket.Controllers
{
    
    public class HomeController : Controller
    {
        private ProduitViewModel vm = new ProduitViewModel();
        private ProduitDal dal = new ProduitDal();
        public ActionResult Index()
        {  
             vm.Pcs = dal.findByCategorie("pc");
             vm.Watchs = dal.findByCategorie("watch");
             vm.phones = dal.findByCategorie("phone");
            
            if (vm.phones==null && vm.Watchs==null && vm.Pcs==null)
            {
                return View("AnyProduct");
            }
            else{
                return View(vm);
            }    
        }

      
    }
}