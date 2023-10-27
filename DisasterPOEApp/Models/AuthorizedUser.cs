using System.ComponentModel.DataAnnotations;

namespace DisasterPOEApp.Models
{
    public class AuthorizedUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }



    }
}
