using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CajunCars.Pages.Vehicles
{
    public class VehicleSearch : PageModel
    {
        public void OnGet()
        {
            
        }
        
        [BindProperty]
        [Required]
        public string VSType { get; set; }
        
        [BindProperty]
        [Required]
        public string VSColor { get; set; }
        
        [BindProperty]
        [Required]
        public int VSHP { get; set; }
    }
}