
using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.LoginModel
{
    public class Login
    {
        public int loginId { get; set; }
        
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }    

    }
}
