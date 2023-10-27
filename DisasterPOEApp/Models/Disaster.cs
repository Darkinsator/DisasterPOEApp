using System;
using System.ComponentModel.DataAnnotations;

namespace DisasterPOEApp.Models
{
    public class Disaster
    {

        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string AidType { get; set; }
    }
}
