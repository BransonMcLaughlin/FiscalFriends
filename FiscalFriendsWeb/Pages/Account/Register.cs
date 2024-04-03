using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.Account
{
    public class Register : PageModel
    {
        [BindProperty]
        public User newUser { get; set; }

        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(!EmailExists(newUser.Email))
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "The Email address already exists! Try a different one.");
                    return Page();
                }
            }
            return Page();
        }

        private bool EmailExists(String email)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM [User] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
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

        private void RegisterUser()
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "INSERT INTO [user](FirstName, LastName, Email, PhoneNumber, UserName, PasswordHash, Birthday, AccountMade, LastLoggedIn)" +
                                          "VALUES(@firstName, @lastName, @email, @phoneNumber, @userName, @passwordhash, @birthday, @accountMade, @lastLoggedIn)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", newUser.FirstName);
                cmd.Parameters.AddWithValue("@lastName", newUser.LastName);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", newUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@userName", newUser.UserName);
                cmd.Parameters.AddWithValue("@lastLoggedIn", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@passwordhash", SecurityHelper.generatePasswordHash(newUser.Password));
                cmd.Parameters.AddWithValue("@birthday", newUser.Birthday);
                cmd.Parameters.AddWithValue("@accountMade", DateTime.Now.ToString());
                //3. open the database
                conn.Open();
                //4. execute the command
                cmd.ExecuteNonQuery();
            }
        }

       
    }
}