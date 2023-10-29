using System;
using System.Collections.Generic;

namespace CL2_MiguelHuaman.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public decimal? Amount { get; set; }
        public bool? Active { get; set; }
    }
}
