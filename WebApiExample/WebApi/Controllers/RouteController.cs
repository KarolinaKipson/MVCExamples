using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    //atribute routing: definicija ruti na samim akcijama i kontroleru, rijetko u MVC, cesto u web api
    //imaju prednost nad rutama u web configu
    [RoutePrefix("route22")]
    public class RouteController : ApiController
    {
        [HttpGet]//moramo ju definirati kao http get ako se ne zove get
        [Route("main")]
        public string Hello()
        {
            return "Hello!";
        }

        [HttpGet]
        [Route("hello/{poruka}")] //mora se isto zvati kao parametar
        public string Hello(string poruka)
        {
            return poruka;
        }

        [HttpGet]
        [Route("hello/{poruka}/{ime}")] //mora se isto zvati kao parametar
        public string Hello(string poruka, string ime)
        {
            return poruka + " " + ime;
        }
    }
}
