using MoviesAPI.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Ime")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Godina")]
        public int Year { get; set; }
        [Display(Name = "Vrsta")]
        public string Genre { get; set; } = string.Empty;

      
    }
}
