using System;
using System.ComponentModel.DataAnnotations;

namespace DisasterApp.Models
{
    public class MoneyDonation
    {
        [Key]
        public int id { get; set; }
        public int amount { get; set; }
        [Required]
        public string description { get; set; }
        public DateTime date { get; set; }
       

    }
}
