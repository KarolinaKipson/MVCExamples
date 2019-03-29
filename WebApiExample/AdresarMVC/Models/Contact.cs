using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdresarMVC.Models
{
    //definirati model na klijentu koji odgovara modelu u web apiju 
    //mora odgovarati po imenu i tipu prop(za deserijaliziciju jsona)
    public class Contact
    {
            public int Id { get; set; }
            public bool Active { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Adress { get; set; }
     }
}