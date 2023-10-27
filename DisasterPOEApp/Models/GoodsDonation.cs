using System.ComponentModel.DataAnnotations;

namespace DisastePOEApp.Models
{
    public class GoodsDonation
    {

        [Key]
        public int id { get; set; }
        public string category { get; set; }
        [Required]
        public string description { get; set; }
        public int items { get; set; }
        public string date { get; set; }

    } 
}
