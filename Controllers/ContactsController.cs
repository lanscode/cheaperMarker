using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheaperMarket.Models;

namespace CheaperMarket.Controllers
{
    public class ContactsController : Controller
    {
        private ContactDal dal = new ContactDal();
        private ContactViewModel vm = new ContactViewModel();
        private UserDal udal = new UserDal();
        private FournisseurDal fdal;
        private Fournisseur fournisseur;
        private UserInstance userInstance;
        // GET: Contacts
        [Authorize]
        public ActionResult Index()
        {
            userInstance = new UserInstance();
            userInstance = udal.findByUserName(User.Identity.Name);
            if(userInstance.UserType=="Fournisseur")
            {
                fournisseur = fdal.findByCode(userInstance.Code);
                List<Contact> contacts = dal.findByFournisseur(fournisseur);
                vm.UserInstance = userInstance;
                vm.Contacts = contacts;
                return View(vm);
            }else if (userInstance.UserType == "Admin")
            {
                List<Contact> contacts = dal.findAll();
                vm.UserInstance = userInstance;
                vm.Contacts = contacts;
                return View(vm);
            }
            else
            {

                return View("Error");
            }

        }
        [Authorize]
        public ActionResult Create()
        {
            userInstance = new UserInstance();
            userInstance = udal.findByUserName(User.Identity.Name);
            if (userInstance.UserType == "Fournisseur")
            {
                return View();
            }
            else if (userInstance.UserType == "Admin")
            {
                List<Fournisseur> Fournisseurs = fdal.findAll();
                vm.UserInstance = userInstance;
                vm.Fournisseurs = Fournisseurs;
                return View(vm);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Produits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "id,objet,message")] Contact contact)
        {
            if (ModelState.IsValid)
            {

                userInstance = new UserInstance();
                userInstance = udal.findByUserName(User.Identity.Name);
                if (userInstance.UserType == "Fournisseur")
                {
                    fournisseur = fdal.findByCode(userInstance.Code);
                    contact.type = "from";
                    contact.Fournisseur = fournisseur;

                    dal.create(contact);
                    return RedirectToAction("Index", "Home");
                }
                else if (userInstance.UserType == "Admin")
                {
                    int id = Convert.ToInt32(Request.Form["idFournisseur"]);
                    fournisseur = fdal.find(id);
                    contact.type = "to";
                    contact.Fournisseur = fournisseur;
                    dal.create(contact);
                    return RedirectToAction("Index", "Home");
                }else
                {
                    return View("Error");
                }
         
            }
            return View(contact);

        }

    }
}