using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CajunCars.AutoGenModels;

namespace CajunCars.Pages.Vehicles
{
    public class DetailsModel : PageModel
    {
        private readonly CajunCars.AutoGenModels.Business _context;

        public DetailsModel(CajunCars.AutoGenModels.Business context)
        {
            _context = context;
        }

        public StoredVehicle StoredVehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoredVehicle = await _context.StoredVehicles.FirstOrDefaultAsync(m => m.Vin == id);

            if (StoredVehicle == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
