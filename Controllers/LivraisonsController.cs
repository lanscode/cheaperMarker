using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheaperMarket.Models;

namespace CheaperMarket.Controllers
{
    [Authorize]
    public class LivraisonsController : Controller
    {
        private CommandeDal cmdal = new CommandeDal();
        private CommandeViewModel vm = new CommandeViewModel();
        private LivariasonDAl dal = new LivariasonDAl();
        private AgentDal adal = new AgentDal();
        private UserDal udal = new UserDal();
        // GET: Livraisons
      
        public ActionResult Index()
        {
            UserInstance user=udal.findByUserName(User.Identity.Name);
            vm.user = user;
            vm.CommandesLivrees = cmdal.findByStatus("livree");
            vm.CommandesEnCours = cmdal.findByStatus("en cours");
            return View(vm);
        }


        public ActionResult Confirmer(int? id)
        {
            
            return View();
        }


        // POST: Livraisons/Create
        [HttpPost ,ActionName("Confirmer")]
        public ActionResult Confirmer(int id)
        {

            if (id>0)
            {
                UserInstance userInstance = udal.findByUserName(User.Identity.Name);
                Commande cm = cmdal.find(id);
                cm.statut = "livree";
                cmdal.edit(cm);
                Livraison livraison = new Livraison();
                livraison.Commande = cm;
                livraison.Agent = adal.findByCode(userInstance.Code);
                dal.add(livraison);

                ViewData["confirmation"] = "Livraison confirmée avec succès";
                return RedirectToAction("Index");

            }

            ViewData["confirmation"] = "Livraison n'est pas été confirmé! Veillez réessayer ";
            return RedirectToAction("Index");
            
        }

        
        
    }
}
