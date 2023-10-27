using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisasterPOEApp.Models
{
    public class ResourceAllocation
    {
        [Key]
        public int Id { get; set; }
        public int DisasterId { get; set; }
        public int MoneyDonationId { get; set; }
        public int AmountAllocated { get; set; }
        public string Description { get; set; }
        public DateTime AllocationDate { get; set; }
    }
}