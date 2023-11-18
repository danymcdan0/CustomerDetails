using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDetails.Models.Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(0,110)]
        [Required(ErrorMessage = "Age is required between [0-110]")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Postcode is required")]
        public string PostCode { get; set; }

        [DisplayName("Height (meters)")]
        [Range(0.01, 2.50)]
        [Required(ErrorMessage = "Height is required between [0.01-2.50]")]
        public double Height { get; set; }
    }
}
