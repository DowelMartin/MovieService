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
        [Required]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public string Description { get; set; }
        public string ProductionCountries { get; set; }
        public string Genres { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string Thumbnail { get; set; }
        public ICollection<MovieComment> MovieComments { get; set; }
        public List<Watchlist> Watchlists { get; set; }
    }
}
