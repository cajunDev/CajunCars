using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CajunCars.AutoGenModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CajunCars.Pages
{
    public class Dealership1 : PageModel
    {
        public void OnGet()
        {
            
        }
    }

    public static class DealerEmployeeList
    {
        
        public static List<string> GetEmployeesList(string dealerID)
        {
            List<string> AllEmployees = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.Employees
                        orderby ci.Name
                        where ci.DId == dealerID
                        select ci;

                    if (!results.Any())
                    {
                        AllEmployees.Add($"");
                        return AllEmployees;
                    }

                    
                    foreach (var c in results)
                        AllEmployees.Add($"{c.DId} ,{c.EId} ,{c.Name} ,{c.Position} ,{c.Pay}");
                    return AllEmployees;
                }
                catch (Exception e)
                {
                    AllEmployees.Add( $"Error searching for employees at  {dealerID}");
                    return AllEmployees;
                }
            }
        }
    }
    
    
    public static class DealerVehicleList
    {
        
        public static List<string> GetVehicleList(string dealerID)
        {
            List<string> AllVehicles = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.StoredVehicles
                        orderby ci.Make
                        where ci.DId == dealerID
                        select ci;

                    if (!results.Any())
                    {
                        AllVehicles.Add($"");
                        return AllVehicles;
                    }

                
                    foreach (var c in results)
                        AllVehicles.Add($"{c.DId} ,{c.Vin} ,{c.Make} ,{c.Model} ,{c.Color} ,{c.Type} ,{c.Hp} ,{c.Price}");
                    return AllVehicles;
                }
                catch (Exception e)
                {
                    AllVehicles.Add( $"Error searching for vehicles at {dealerID}");
                    return AllVehicles;
                }
            }
        }
    }
    
    
}