
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace FiscalFriendsWeb.Pages.LoginModel
{
    public class Login
    {
        public int loginId { get; set; }
        
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }    
        
        public bool rememberMe { get; set; }

        public string Email { get; set; }
    }
}
