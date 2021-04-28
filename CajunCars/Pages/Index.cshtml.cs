using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CajunCars.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        [BindProperty] [Required] public string UName { get; set; }

        [BindProperty] [Required] public string UPass { get; set; }
        
        [BindProperty] [Required] public string MSG { get; set; }


        public IActionResult OnPost()
        {
            using (var db = new World.World())
            {
                try
                {
                    var results =
                        from ci in db.UserAccounts
                        where ci.Username == UName && ci.Password == UPass
                        select ci;

                    if (!results.Any())
                    {
                        MSG = "Invalid Login Credentials";
                        return Page();
                    }

                    return RedirectToPage("Landing");
                }
                catch (Exception e)
                {
                    MSG = "Invalid Login Credentials";
                    return Page();
                }
            }
        }
    }
    
}