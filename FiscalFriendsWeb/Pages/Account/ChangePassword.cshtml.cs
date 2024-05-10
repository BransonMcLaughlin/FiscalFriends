using FiscalFriendsWeb.Pages.ProfileModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiscalFriendsWeb.Pages.Account
{

    [BindProperties]
    [Authorize]

    public class ChangePasswordModel : PageModel

    {

    public Profile Person { get; set; } = new Profile();

    public void OnGet()
        {
        }
    }
}
