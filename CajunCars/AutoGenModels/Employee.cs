using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CajunCars.AutoGenModels
{
    public partial class Employee
    {
        [Key]
        [Column("E_ID")]
        public string EId { get; set; }
        [Column("D_ID")]
        public string DId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public long? Pay { get; set; }
    }
}
