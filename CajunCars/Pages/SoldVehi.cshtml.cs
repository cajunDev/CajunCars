using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CajunCars.AutoGenModels;

namespace CajunCars.Pages
{
    public class SoldVehiModel : PageModel
    {
        private readonly CajunCars.AutoGenModels.Business _context;

        public SoldVehiModel(CajunCars.AutoGenModels.Business context)
        {
            _context = context;
        }

        public IList<SoldVehicle> SoldVehicle { get;set; }

        public async Task OnGetAsync()
        {
            SoldVehicle = await _context.SoldVehicles.ToListAsync();
        }
    }
}
