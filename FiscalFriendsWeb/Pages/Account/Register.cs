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
                //Make sure the email does not exist before registering the user

                if (EmailDNE(newUser.Email))
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "The email address already exist. Try a different one.");
                    return Page();
                }
                
            }
            else
            {
                return Page();
            }
        }

        private void RegisterUser()
        {
            using (SqlConnection con = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "INSERT INTO [user](FirstName, LastName, Email, PhoneNumber, UserName, PasswordHash, Birthday, AccountMade, LastLoggedIn)" +
                                         "VALUES(@firstName, @lastName, @email, @phoneNumber, @userName, @passwordhash, @birthday, @accountMade, @lastLoggedIn)";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@firstName", newUser.FirstName);
                cmd.Parameters.AddWithValue("@lastName", newUser.LastName);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", newUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@userName", newUser.UserName);
                cmd.Parameters.AddWithValue("@lastLoggedIn", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@passwordhash", SecurityHelper.generatePasswordHash(newUser.Password));
                cmd.Parameters.AddWithValue("@birthday", newUser.Birthday);
                cmd.Parameters.AddWithValue("@accountMade", DateTime.Now.ToString());
                con.Open();
                //4. execute the command
                cmd.ExecuteNonQuery();

               

            }
        }

        private bool EmailDNE(string email)
        {
            using(SqlConnection conn = new SqlConnection (SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM [User] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}