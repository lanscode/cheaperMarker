using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheaperMarket.Models;

namespace CheaperMarket.Controllers
{
   
    public class CommandesController : Controller
    {
        public CommandeViewModel cvm = new CommandeViewModel();
        private CommandeDal db = new CommandeDal();
        private ClientDal clientdal=new ClientDal();
        private UserInstance uc=new UserInstance();
        private UserDal ucdal=new UserDal();
        private Client client=new Client();
        private ProduitDal dal = new ProduitDal();
        private LivariasonDAl ldal = new LivariasonDAl();
        private AgentDal adal = new AgentDal();


        // GET: Commandes
        [Authorize]
        public ActionResult Index()
        {
            uc= ucdal.findByUserName(User.Identity.Name);
            if (uc.UserType=="Client")
            {
                client = clientdal.findByCode(uc.Code);
                cvm.CommandeByClient = db.findByClient(client);

                if (cvm.CommandeByClient.Count == 0)
                {
                    return View("CommandeNotFound");
                }else
                {

                    cvm.user = uc;
                    return View(cvm);
                }
             }else if (uc.UserType=="Admin")
            {
                cvm.AllCommandes = db.findAll();
                if (cvm.AllCommandes.Count==0)
                    return View("AnyCommande");
                cvm.user = uc;
                return View(cvm);
            }
            return View("CommandeNotFound");
        }
        [Authorize]
        public ActionResult Create(int? id)
        {
            uc = ucdal.findByUserName(User.Identity.Name);
            if (uc.UserType != "CLient")
                return View("Error");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(int id)
        {
            uc = ucdal.findByUserName(User.Identity.Name);
            if (ModelState.IsValid)
            {
                Client client = clientdal.findByCode(uc.Code);
                Commande cm = new Commande();
                int q = Convert.ToInt32(Request.Form["quantite"]);
                Produit p = dal.find(id);
                int q1 = p.quantite - q;
                dal.edit(p, q1);
                cm.statut = "en cours";
                cm.quantite = q;
                cm.Produit = p;
                cm.prix = p.prix * q;
                cm.dateC = DateTime.Now;
                cm.client = client;
                cm.adresse = Request.Form["adresse"];
                db.add(cm);

                return RedirectToAction("Index");

            }
            else
            {
                cvm.adresse = Request.Form["adresse"];
                cvm.quantite = Convert.ToInt32(Request.Form["quantite"]);
                return View(cvm);
            }



        }

       

         // GET: Commandes/Create
         public ActionResult Deliver(int?id)
         {
             return View();
         }

         // POST: Commandes/Create
         // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
         // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Deliver(int id)
         {
            Livraison livraison = new Livraison();
            Commande commande = db.find(id);
            uc = ucdal.findByUserName(User.Identity.Name);
            Agent agent = adal.findByCode(uc.Code);
            if (ModelState.IsValid)
             {  
                commande.statut = "livrée";
                db.edit(commande);
                livraison.Commande = commande;
                livraison.Agent = agent;
                RedirectToAction("Index");
             }

             return View(commande);
         }

       /*  // GET: Commandes/Edit/5
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Commande commande = db.Commandes.Find(id);
             if (commande == null)
             {
                 return HttpNotFound();
             }
             return View(commande);
         }

         // POST: Commandes/Edit/5
         // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
         // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "id,dateC,adresse,statut,prix")] Commande commande)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(commande).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(commande);
         }

         // GET: Commandes/Delete/5
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Commande commande = db.Commandes.Find(id);
             if (commande == null)
             {
                 return HttpNotFound();
             }
             return View(commande);
         }

         // POST: Commandes/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             Commande commande = db.Commandes.Find(id);
             db.Commandes.Remove(commande);
             db.SaveChanges();
             return RedirectToAction("Index");
         }

         protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }*/
    }
}
