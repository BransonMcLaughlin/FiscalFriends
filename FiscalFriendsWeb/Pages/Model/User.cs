using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.UserModel
  
{
    public class User
    {
        [Required]
        public int Userid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string userName {  get; set; }
        
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        

    }
}
