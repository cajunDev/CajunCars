using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CajunCars.AutoGenModels{
    [Keyless]
    public partial class SoldVehicle
    {
        
        [Key]
        [Column("VIN")]
        public string Vin { get; set; }
        [Column("E_ID")]
        public string EId { get; set; }
        public long? Price { get; set; }
        [Column("Sales_Month")]
        public string SalesMonth { get; set; }
        [Column("Sales_Year")]
        public string SalesYear { get; set; }
    }
}
