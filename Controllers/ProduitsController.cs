using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheaperMarket.Models;

namespace CheaperMarket.Controllers
{
    public class ProduitsController : Controller
    {
        private ProduitDal dal = new ProduitDal();
        public ProduitViewModel vm = new ProduitViewModel();
        private CommandeDal cmdal = new CommandeDal();
        private Commande cm = new Commande();
        private ClientDal clientdal = new ClientDal();
        private UserDal udal = new UserDal();

        // GET: Produits/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
            {
                UserInstance user = udal.findByUserName(User.Identity.Name);
                vm.user = user;
            }
            else
            {
                vm.user = null;
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = dal.find(id);


            if (produit == null)
            {
                return HttpNotFound();
            }
            if (produit.categorie == "pc")
                ViewData["nom"] = "pc/" + produit.label + ".jpg";
            if (produit.categorie == "watch")
                ViewData["nom"] = "watchs/" + produit.label + ".jpg";
            if (produit.categorie == "phone")
                ViewData["nom"] = "phones/" + produit.label + ".jpg";
            vm.Produit = produit;
            return View(vm);
        }

        public ActionResult findByLabel()
        {
            string label = Request.Form["label"];
            if (label.Length == 0)
                return View("Index", "Home");
            if (dal.exist(label))
            {
                Produit p = dal.findByLabel(label);
                return Details(p.id);
            }else
            {
                ViewData["message"] = "Nous sommes désolé,Ce produit n'existe pas sur notre site!";
                return View("Index", "Home");
            }
           

        }

        // GET: Produits/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,label,description,categorie,prix,quantite")] Produit produit)
        {
            if (ModelState.IsValid)
            {

                dal.add(produit);
                return RedirectToAction("Index", "Home");
            }
            return View(produit);
        }
       

    }
}
