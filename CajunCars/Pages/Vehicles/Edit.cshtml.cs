using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CajunCars.AutoGenModels;

namespace CajunCars.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        private readonly CajunCars.AutoGenModels.Business _context;

        public EditModel(CajunCars.AutoGenModels.Business context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StoredVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoredVehicleExists(StoredVehicle.Vin))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StoredVehicleExists(string id)
        {
            return _context.StoredVehicles.Any(e => e.Vin == id);
        }
    }
}
