using AdresarMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AdresarMVC.Controllers
{
    public class ContactController : Controller
    {
        private string _apiUrl = ConfigurationManager.AppSettings["WebApiUrl"];

        // GET: Contact
        public ActionResult Index()
            
        {
            List<Contact> contacts = null;

            using(HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })//host adresa apija npr:googleapis.com
            {
                //dohvat http odgovora iz apija
                var response = client.GetAsync("api/contact").Result;
                //citanje http poruke
                var message = response.Content.ReadAsStringAsync().Result;
                //deserijalizacija
                contacts = JsonConvert.DeserializeObject<List<Contact>>(message);
            }
            return View(contacts);
        }

        public ActionResult Edit(int id)
        {
            Contact model = null;
            using(HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })
            {
                var response = client.GetAsync($"api/contact/{id}").Result;
                var message = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Contact>(message);
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            Contact model = null;

            using(HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })
            {

                var response = client.PostAsJsonAsync("api/contact", contact).Result;

                var message = response.Content.ReadAsStringAsync().Result;

                model = JsonConvert.DeserializeObject<Contact>(message);
            }

            return View(model);
        }
    }
}