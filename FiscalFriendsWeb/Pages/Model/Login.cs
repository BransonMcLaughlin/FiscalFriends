using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.LoginModel
{
    public class Login
    {
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }    

    }
}
