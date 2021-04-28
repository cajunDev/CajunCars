using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CajunCars.AutoGenModels{
    [Keyless]
    public partial class Dealership
    {
        [Column("D_ID")]
        public string DId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Brand { get; set; }
    }
}
