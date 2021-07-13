using MovieService.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Models
{
    public class Watchlist
    {
        [Key]
        public int ID { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public string UserID { get; set; }
        public MovieServiceUser User { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Today;

    }
}