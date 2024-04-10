using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace FiscalFriendsWeb.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public UserProfile profile { get; set; } = new UserProfile();
        public void OnGet()
        {
            PopulateProfile();
        }

        private void PopulateProfile()
        {
            string email = HttpContext.User.FindFirstValue(ClaimVlaueTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString())) ;
            {
                string cmdText = "SELECT FirstName, LastName, Email From Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();

            }
        }
    }
}
