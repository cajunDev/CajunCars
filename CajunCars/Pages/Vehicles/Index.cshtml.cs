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
    public class IndexModel : PageModel
    {
        private readonly CajunCars.AutoGenModels.Business _context;

        public IndexModel(CajunCars.AutoGenModels.Business context)
        {
            _context = context;
        }

        public IList<StoredVehicle> StoredVehicle { get;set; }

        public async Task OnGetAsync()
        {
            StoredVehicle = await _context.StoredVehicles.ToListAsync();
        }
    }
    
    
    public static class VehicleList
    {
        
        public static List<string> GetVehicleListType(string type)
        {
            List<string> AllVehicles = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.StoredVehicles
                        orderby ci.Make
                        where ci.Type == type
                        select ci;

                    if (!results.Any())
                    {
                        AllVehicles.Add($"");
                        return AllVehicles;
                    }

                    AllVehicles.Add($"All {type}  at dealerships :");
                    foreach (var c in results)
                        AllVehicles.Add($"DealershipID : {c.DId} ,  VIN: {c.Vin}, Make: {c.Make}, Model: {c.Model}, Color: {c.Color}, Type: {c.Type} Horsepower: {c.Hp}, Price {c.Price}");
                    return AllVehicles;
                }
                catch (Exception e)
                {
                    AllVehicles.Add( $"Error searching for vehicles of type {type}");
                    return AllVehicles;
                }
            }
        }
        
        public static List<string> GetVehicleListColor(string color)
        {
            List<string> AllVehicles = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.StoredVehicles
                        orderby ci.Make
                        where ci.Color == color
                        select ci;

                    if (!results.Any())
                    {
                        AllVehicles.Add($"");
                        return AllVehicles;
                    }

                    AllVehicles.Add($"All {color} vehicles  at dealerships :");
                    foreach (var c in results)
                        AllVehicles.Add($"DealershipID : {c.DId} ,  VIN: {c.Vin}, Make: {c.Make}, Model: {c.Model}, Color: {c.Color}, Type: {c.Type} Horsepower: {c.Hp}, Price {c.Price}");
                    return AllVehicles;
                }
                catch (Exception e)
                {
                    AllVehicles.Add( $"Error searching for vehicles of color {color}");
                    return AllVehicles;
                }
            }
        }
        
        public static List<string> GetVehicleListHP(int HP)
        {

            
            List<string> AllVehicles = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.StoredVehicles
                        orderby ci.Make
                        where ci.Hp >= HP
                        select ci;

                    if (!results.Any())
                    {
                        AllVehicles.Add($"");
                        return AllVehicles;
                    }

                    AllVehicles.Add($"All vehicles  at dealership with the minimum Horse Power of : {HP}:");
                    foreach (var c in results)
                        AllVehicles.Add($"DealershipID : {c.DId} ,  VIN: {c.Vin}, Make: {c.Make}, Model: {c.Model}, Color: {c.Color}, Type: {c.Type} Horsepower: {c.Hp}, Price {c.Price}");
                    return AllVehicles;
                }
                catch (Exception e)
                {
                    AllVehicles.Add( $"Error searching for vehicles of with HP Of  {HP}");
                    return AllVehicles;
                }
            }
        }
    }
}
