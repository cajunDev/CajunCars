using System;
using System.Collections.Generic;
using System.Linq;
using CajunCars.AutoGenModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CajunCars.Pages
{
    public class Landing : PageModel
    {
        public void OnGet()
        {
            
        }
        
        public static class DealershipList
        {
            public static List<string> GetDealershipList()
            {
                List<string> AllDealerShips = new List<string>();
                using (var db = new CajunCars.AutoGenModels.Business())
                {
                    try
                    {
                        var results =
                            from ci in db.Dealerships
                            select ci;

                        if (!results.Any())
                        {
                            AllDealerShips.Add($"");
                            return AllDealerShips;
                        }


                        foreach (var c in results)
                            AllDealerShips.Add(
                                $"DealershipID: {c.DId}, Address: {c.Address}, Phone: {c.Phone}, Brand: {c.Brand}");
                        return AllDealerShips;
                    }
                    catch (Exception e)
                    {

                        AllDealerShips.Add("Error searching for dealerships ");
                        return AllDealerShips;
                    }
                }
            }
        }
    }
}