using System.ComponentModel.DataAnnotations;
using MoviesAPI.Data;
namespace MoviesAPI.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Vrsta")]
        [Required(ErrorMessage = "Godina je obavezno")]
        public int Year { get; set; }
        [Display(Name = "Godina")]
        [Required(ErrorMessage = "Godina je obavezno")]
        public string Genre { get; set; } = string.Empty;

    }
}
