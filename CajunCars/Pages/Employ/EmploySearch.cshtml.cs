using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CajunCars.Pages.Employ
{
    public class EmploySearch : PageModel
    {
        public void OnGet()
        {
            
        }
        
        [BindProperty]
        [Required]
        public string PosEmploy { get; set; }
    }
}