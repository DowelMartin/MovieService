using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Models
{
    public class MovieComment
    {
        [Key]
        public int ID { get; set; }
        public string Comments { get; set; }
        public DateTime PublishedDate { get; set; }
        public int MoviesID { get; set; }
        public Movie Movies { get; set; }
        public int Rating { get; set; }
    }
}
