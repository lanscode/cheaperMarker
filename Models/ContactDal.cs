using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheaperMarket.Models
{
    public class ContactDal : ContactIdal
    {
        private CmarketDBContext context;
        public ContactDal()
        {
            context = new CmarketDBContext();
        }
        public void create(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            context.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public List<Contact> findAll()
        {
            return context.Contacts.ToList();
        }
        public List<Contact> findByFournisseur(Fournisseur fournisseur)
        {
            List<Contact> contacts = (from c in context.Contacts
                                      where c.Fournisseur.code == fournisseur.code
                                      select c
                                   ).ToList();
            return contacts;
        }
    }
}