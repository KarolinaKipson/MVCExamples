using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    //api/contact
    //post, get, put, delete
    public class ContactController : ApiController
    {
        AdresarContext ctx = new AdresarContext();
        //[HttpGet] opcionalan
        public List<Contact> Get()
        {
            var request = this.Request;//debugiranje da vidimo sto dolazi od klijenta k nama
            var allContacts = ctx.Contacts.ToList();
            return allContacts;//framework sam radi serijalizaciju objekata u xml ili json 
        }
        //api/contact/{id}
        public IHttpActionResult Get(int id)//ovaj return tip podataka se koristi u praksi
        {
            try
            {
                var contact = ctx.Contacts.Where(x => x.Id == id).FirstOrDefault();

                if (contact != null)
                {
                    return Ok(contact); //http status 200
                }
                else
                {
                    return NotFound(); //http status 404
                }
            }
            catch (Exception)
            {

                return InternalServerError();//http status kod 500
            }
           
         }
        [HttpPost]
        public IHttpActionResult Edit(Contact contact)
        {
            var cont = ctx.Contacts.Where(x => x.Id == contact.Id).FirstOrDefault();

            cont.FirstName = contact.FirstName;
            ctx.SaveChanges();

            return Ok(contact);
        }
    }
}
