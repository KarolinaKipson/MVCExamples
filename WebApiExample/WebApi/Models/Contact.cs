using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(150)]
        public string Adress { get; set; }
    }
}



    
