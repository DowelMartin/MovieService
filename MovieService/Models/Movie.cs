using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ProductionCountries { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Thumbnail { get; set; }
        public ICollection<MovieComment> MovieComments { get; set; }
    }
}
