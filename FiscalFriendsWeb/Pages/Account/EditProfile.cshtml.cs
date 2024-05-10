using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.ProfileModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FiscalFriendsWeb.Pages.Account
{
    [BindProperties]
    [Authorize]
    public class EditProfileModel : PageModel
    {

        public Profile Person { get; set; } = new Profile();
        public void OnGet(int id)
        {
            PopulateProfile(id);
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                if (!EmailExists(Person.Email, id))
                {
                    using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                    {
                        string cmdText = "UPDATE [User] SET FirstName=@FirstName, LastName=@LastName, Email=@Email, PhoneNumber=@PhoneNumber, UserName=@UserName, Birthday=@Birthday WHERE PersonID=@PersonID";
                        SqlCommand cmd = new SqlCommand(cmdText, conn);
                        cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", Person.LastName);
                        cmd.Parameters.AddWithValue("@Email", Person.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", Person.PhoneNumber);
                        cmd.Parameters.AddWithValue("@UserName", Person.UserName);
                        cmd.Parameters.AddWithValue("@Birthday", Person.Birthday);
                        cmd.Parameters.AddWithValue("@PersonID", id);
                        //3. open the database
                        conn.Open();
                        //4. execute the command
                        cmd.ExecuteNonQuery();
                        return RedirectToPage("Logout");
                    }
                }
                else
                {
                    ModelState.AddModelError("Person.Email", "This Email address is already in use! Try a different one.");
                    return Page();
                }
            }
            else
            {
                return Page();
            }

        }

        private bool EmailExists(String email, int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM [User] WHERE Email=@email AND NOT PersonID=@PersonID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@PersonID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
