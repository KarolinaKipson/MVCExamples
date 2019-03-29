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
    public class PostCommentController : Controller
    {
        private string _apiUrl = ConfigurationManager.AppSettings["jsonplaceholder"];
        // GET: PostComment
        public ActionResult Index()
        {
            List<Post> posts = null;

            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })//host adresa apija npr:googleapis.com
            {
                //dohvat http odgovora iz apija
                var response = client.GetAsync("comments?postId=1").Result;
                //citanje http poruke
                var message = response.Content.ReadAsStringAsync().Result;
                //deserijalizacija
                posts = JsonConvert.DeserializeObject<List<Post>>(message);
            }
            return View(posts);
        }

        public ActionResult Details(int id)
        {
            List<Post> model = null;
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(_apiUrl) })//host adresa apija npr:googleapis.com
            {
                //dohvat http odgovora iz apija
                var response = client.GetAsync($"comments?id={id}&postId=1").Result;
                //citanje http poruke
                var message = response.Content.ReadAsStringAsync().Result;
                //deserijalizacija
                model = JsonConvert.DeserializeObject<List<Post>>(message);
               
            }
            return View(model);

        }
    }
}