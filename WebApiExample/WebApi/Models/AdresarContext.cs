using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class AdresarContext: DbContext
    {
        public AdresarContext() : base("AdresarDB")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}