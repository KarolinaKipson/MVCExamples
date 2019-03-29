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
    public class ToDoController : Controller
    {
        private string _apiUrl = ConfigurationManager.AppSettings["jsonplaceholder"];

        // GET: Comics
        public ActionResult Index()
        {
            Todo model = null;
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })//host adresa apija npr:googleapis.com
            {
                //dohvat http odgovora iz apija
                var response = client.GetAsync("todos/1").Result;
                //citanje http poruke
                var message = response.Content.ReadAsStringAsync().Result;
                //deserijalizacija
               model = JsonConvert.DeserializeObject<Todo>(message);
                
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Todo model = null;
            using (HttpClient client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") })
            {
                var response = client.GetAsync($"todos/{id}").Result;
                var message = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Todo>(message);
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            Todo model = null;

            using (HttpClient client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") })
            {

                var response = client.PostAsJsonAsync("todos/1", todo).Result;

                var message = response.Content.ReadAsStringAsync().Result;

                model = JsonConvert.DeserializeObject<Todo>(message);
            }

            return View(model);
        }


    }
    }
