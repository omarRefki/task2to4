using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace task2.Models
{
   
    public class VMproject
    {
        [Display(Name = "Project Number")]
        [Required]
        public int Pnumber { get; set; }


        [Display(Name = "Project Name")]
        [Required]
        [MinLength(5)]
        public string? Name { get; set; }


        [Display(Name = "Project Location")]
        [Required]
        [Remote("locationName", "customValidation", ErrorMessage = "(cairo - alex - giza ) are allowed")]
        public string? location { get; set; }

        [Display(Name = "Confirm Location")]
        [Compare("location", ErrorMessage = "location doesnot match")]
        public string? ConfirmLocation { get; set; }
    }
    
}
