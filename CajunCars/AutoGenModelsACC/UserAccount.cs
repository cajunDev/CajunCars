using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace World
{
    public partial class UserAccount
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
