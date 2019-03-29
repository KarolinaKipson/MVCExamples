using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace Entity.MoviesDb.Models
{
    public partial class EntityMoviesDB : DbContext 
    {
        public EntityMoviesDB() : base("EntityMoviesDB")
        {

           
        }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

    }
}