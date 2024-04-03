using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FiscalFriendsWeb.Pages.ProfileModel;

namespace FiscalFriendsWeb.Pages.Account
{
    public class Profile : PageModel
    {
        [BindProperty]
        public Profile userProfile { get; set; }
        public void OnGet()
        {
        }
    }
}
