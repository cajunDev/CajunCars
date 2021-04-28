using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CajunCars.AutoGenModels{
    [Keyless]
    public partial class Commission
    {
        [Column("E_ID")]
        public string EId { get; set; }
        [Column("Comm_Rate", TypeName = "NUMERIC")]
        public double CommRate { get; set; }
    }
}
