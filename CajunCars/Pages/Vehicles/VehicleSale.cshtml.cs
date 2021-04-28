using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CajunCars.AutoGenModels;

namespace CajunCars.Pages.Vehicles
{
    public class VehicleSaleModel : PageModel
    {
        private readonly CajunCars.AutoGenModels.Business _context;

        public VehicleSaleModel(CajunCars.AutoGenModels.Business context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SoldVehicle SoldVehicle { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SoldVehicles.Add(SoldVehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
