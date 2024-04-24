using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.ProfileModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace FiscalFriendsWeb.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public Profile UserProfile { get; set; } = new Profile();
        public void OnGet()
        {
            PopulateProfile();
        }

        private void PopulateProfile()
        {
            string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Username, LastLoggedIn FROM [USER] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows) {
                    reader.Read();
                    UserProfile.FirstName = reader.GetString(0);
                    UserProfile.LastName = reader.GetString(1);
                    UserProfile.UserName = reader.GetString(3);
                    UserProfile.Email = reader.GetString(2);
                    //UserProfile.LastLoggedIn = reader.GetDateTime(4);
                }
            }
        }
    }
}
