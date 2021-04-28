using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CajunCars.AutoGenModels{
    public partial class StoredVehicle
    {
        [Key]
        [Column("VIN")]
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        [Column("HP")]
        public long? Hp { get; set; }
        public long? Price { get; set; }
        [Column("D_ID")]
        public string DId { get; set; }
    }
}
