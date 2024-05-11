using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.ProfileModel;
using FiscalFriendsWeb.Pages.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.Account
{

    [BindProperties]
    [Authorize]

    public class ChangePasswordModel : PageModel

    {

        public User Person { get; set; } = new User();

        public void OnGet(int id)
        {
                PopulateProfile(id);
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                    {
                    string cmdText = "UPDATE [User] SET PasswordHash=@PasswordHash WHERE PersonID=@PersonID";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@PersonID", id);
                    cmd.Parameters.AddWithValue("@PasswordHash", SecurityHelper.generatePasswordHash(Person.Password));
                    //3. open the database
                    conn.Open();
                    //4. execute the command
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("Profile");
                }
            }
            else
            {
                return Page();
            }

        }

        private void PopulateProfile(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "SELECT FirstName, LastName, Email, PhoneNumber, UserName, Birthday FROM [User] WHERE PersonID=@PersonID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@PersonID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Person.FirstName = reader.GetString(0);
                    Person.LastName = reader.GetString(1);
                    Person.Email = reader.GetString(2);
                    Person.PhoneNumber = reader.GetString(3);
                    Person.UserName = reader.GetString(4);
                    Person.Birthday = DateOnly.FromDateTime(reader.GetDateTime(5));
                }
            }
        }
    }
}
