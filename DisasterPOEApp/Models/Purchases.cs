using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisasterPOEApp.Models
{
    public class Purchases
    {
        [Key]
        public int id { get; set; }
        public int amount { get; set; }    
        public string description { get; set; }
        public string name { get; set; }
    }
}