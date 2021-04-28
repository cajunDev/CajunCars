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
    public class DeleteModel : PageModel
    {
        private readonly CajunCars.AutoGenModels.Business _context;

        public DeleteModel(CajunCars.AutoGenModels.Business context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoredVehicle = await _context.StoredVehicles.FindAsync(id);

            if (StoredVehicle != null)
            {
                _context.StoredVehicles.Remove(StoredVehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
