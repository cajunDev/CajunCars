using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CajunCars.AutoGenModels;

namespace CajunCars.Pages.Employ
{
    public class IndexModel : PageModel
    {
        private readonly CajunCars.AutoGenModels.Business _context;

        public IndexModel(CajunCars.AutoGenModels.Business context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
        
       
    }
    
    public static class EmployeeList
    {
        
        public static List<string> GetEmployeesListPosition(string Position)
        {
            List<string> AllEmployees = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.Employees
                        orderby ci.Name
                        where ci.Position == Position
                        select ci;

                    if (!results.Any())
                    {
                        AllEmployees.Add($"");
                        return AllEmployees;
                    }
                    
                    foreach (var c in results)
                        AllEmployees.Add($"Dealership ID: {c.DId}  |  Employee ID: {c.EId}  |  Name: {c.Name}  |  Position: {c.Position}  |  Pay: {c.Pay}");
                    return AllEmployees;
                }
                catch (Exception e)
                {
                    AllEmployees.Add( $"Error searching for employees at  {Position}");
                    return AllEmployees;
                }
            }
        }
        
        public static List<string> GetEmployeesListPay(int Pay)
        {
            List<string> AllEmployees = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.Employees
                        orderby ci.Pay
                        where ci.Pay >= Pay && Pay > 0
                        select ci;

                    if (!results.Any())
                    {
                        AllEmployees.Add($"");
                        return AllEmployees;
                    }
                    
                    foreach (var c in results)
                        AllEmployees.Add($"Dealership ID: {c.DId}  |  Employee ID: {c.EId}  |  Name: {c.Name}  |  Position: {c.Position}  |  Pay: {c.Pay}");
                    return AllEmployees;
                }
                catch (Exception e)
                {
                    AllEmployees.Add( $"Error searching for employees at  {Pay}");
                    return AllEmployees;
                }
            }
        }
        
    }
    
    
}
