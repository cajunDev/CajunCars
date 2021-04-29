using System;
using System.Collections.Generic;
using System.Linq;
using CajunCars.AutoGenModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CajunCars.Pages
{
    public class Commission : PageModel
    {
        public void OnGet()
        {
        }
    }

    public static class EmployeeCommisionList
    {
        public static List<string> GetEmployeeCommisionList()
        {
            List<string> AllEmployeesCommission = new List<string>();
            using (var db = new Business())
            {
                try
                {
                    var results =
                        from ci in db.Commissions
                        join co in db.Employees
                           on ci.EId equals co.EId
                        orderby ci.EId
                     //   where ci.EId == co.EId
                        select new {ci.EId, ci.CommRate, co.Name};

                    var results2 =
                        from ci in db.SoldVehicles
                        join co in db.Commissions
                            on ci.EId equals co.EId
                        orderby ci.EId
                        where ci.EId == co.EId
                        select new {ci.EId, ci.Price};


                    if (!results.Any())
                    {
                        AllEmployeesCommission.Add($"");
                        return AllEmployeesCommission;
                    }


                    foreach (var c in results)
                    {
                        long TotalPrice = 0;
                        var cID = c.EId;
                        foreach (var d in results2)
                        {
                            if (cID == d.EId)
                            {
                                TotalPrice += d.Price.GetValueOrDefault();
                            }
                        }

                        double commissionPay = c.CommRate * TotalPrice;
                             // "123.46"

                        AllEmployeesCommission.Add($"{c.EId} ,{c.Name} ,{String.Format("{0:0.##}", commissionPay)}");
                    }

                    return AllEmployeesCommission;
                }
                catch (Exception e)
                {
                    AllEmployeesCommission.Add($"Error searching for employees by commmission");
                    return AllEmployeesCommission;
                }
            }
        }
    }
}