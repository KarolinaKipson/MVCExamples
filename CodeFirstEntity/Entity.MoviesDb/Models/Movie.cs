using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entity.MoviesDb.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string DirectorName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ReleaseDate { get; set; }
    }
}