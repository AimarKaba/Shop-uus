using System.ComponentModel.DataAnnotations;


namespace Shop.Models.Weather
{
    public class SearchCity
    {
        [Required(ErrorMessage = "You must enter a city name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
    }
}
