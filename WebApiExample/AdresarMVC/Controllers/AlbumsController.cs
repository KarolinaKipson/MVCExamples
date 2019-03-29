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
    public class AlbumsController : Controller
    {
        private string _apiUrl = ConfigurationManager.AppSettings["jsonplaceholder"];
        // GET: Albums
        public ActionResult Index()
        {
            List<Album> albums = null;

            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })//host adresa apija npr:googleapis.com
            {
                //dohvat http odgovora iz apija
                var response = client.GetAsync("albums").Result;
                //citanje http poruke
                var message = response.Content.ReadAsStringAsync().Result;
                //deserijalizacija
                albums = JsonConvert.DeserializeObject<List<Album>>(message);
            }
            return View(albums);
        }

        public ActionResult Details(int id)
        {
            Album model = null;
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })
            {
                var response = client.GetAsync($"albums/{id}").Result;
                var message = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Album>(message);
            }

            return View(model);
            
        }
    }
}