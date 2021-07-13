using MovieService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.ViewModels
{
    public class MovieCommentViewModel
    {
        public string Title { get; set; }
        public List<MovieComment> ListOfComments { get; set; }
        public string Comment { get; set; }
        public int MoviesID { get; set; }
        public int Rating { get; set; }
    }
}
