using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheaperMarket.Models;

namespace CheaperMarket.Controllers
{
    public class ApprovisionnementsController : Controller
    {
        private ProduitDal pdal = new ProduitDal();
        private ApprovisionnementDal dal = new ApprovisionnementDal();
        private ApprovisionnementViewModel vm = new ApprovisionnementViewModel();
        private UserDal ucdal = new UserDal();
        private FournisseurDal fdal = new FournisseurDal();
        
        // GET: Approvisionnements
        [Authorize]
        public ActionResult Index()
        {
            UserInstance uc = ucdal.findByUserName(User.Identity.Name);
            vm.user = uc;
           // List<UserInstances>users=ucdal.findByUserName(uc.UserName)
            if (uc.UserType.CompareTo("Fournisseur")==0)
            {
                 Fournisseur fournisseur = fdal.findByCode(uc.Code);
                 vm.Approvisionnements = dal.findByFournisseur(fournisseur);

                if (vm.Approvisionnements.Count < 1)
                    return View("AnyApprovisionnement");
                 return View(vm);
            }
            else if(uc.UserType=="Admin")
            {
                vm.Approvisionnements = dal.findAll();
                if (vm.Approvisionnements.Count < 1)
                    return View("AnyApprovisionnement");
                return View(vm);
            }
            return View("Error");
        }

        public void edit(int id)
        {
            int q = Convert.ToInt32(Request.Form["quantite"]);
            Produit p = pdal.find(id);
            int quantite = q + p.quantite;
            pdal.edit(p,quantite);
           
        }

        // GET: Approvisionnements/Create
        [Authorize]
        public ActionResult Create(int?id)
        {
            UserInstance uc = ucdal.findByUserName(User.Identity.Name);
            if (uc.UserType != "Fournisseur")
            {
                return View("Error");
            }

            return View();
        }

 
        // POST: Approvisionnements/Create
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
        {
            Approvisionnement approvisionnement = new Approvisionnement();
            UserInstance uc = ucdal.findByUserName(User.Identity.Name);
            if (uc.UserType != "Fournisseur")
            {
                return View("Error");
            }
            Produit produit = pdal.find(id);
            int q = Convert.ToInt32(Request.Form["quantite"]);
            Fournisseur fournisseur= fdal.findByCode(uc.Code);


            if (ModelState.IsValid)
            {
                q = q + produit.quantite;
                pdal.edit(produit, q);
                approvisionnement.Produit = produit;
                approvisionnement.quantite = q;
                approvisionnement.Fournisseur = fournisseur;
                dal.add(approvisionnement);
                RedirectToAction("Index");
            }

            return View(approvisionnement);


        }

       
    }
}
