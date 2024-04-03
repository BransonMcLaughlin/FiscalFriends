using FiscalFriendsBusiness;
using  FiscalFriendsWeb.Pages.LoginModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace FiscalFriendsWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login loginUser { get; set; }
        //public Login() 
        //{

        //}
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // check login credentials
                if (ValidateCredentials())
                {
                    return RedirectToPage("Profile");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid Credentials, Try again.");
                    return Page();
                }
                // if the credentials are valid 
                // redirect user to Profile Page
                // O.W, display error
               

            }
            else
            {
                return Page();
            }


        } // end ActionResult

        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString())) 
                {
                String cmdText = "SELECT PasswordHash, PersonID FROM [User] WHERE Username=@username;";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@username", loginUser.Username);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.VerifyPassword(loginUser.Password, passwordHash))
                        {
                            // Get the personID and use it to update the person record
                            int personID = reader.GetInt32(1);
                            UpdatePersonLoginTime(personID);
                            return true;
                        }
                        else
                        {

                            return false;
                        }
                    }

                    else
                    {
                        return false;
                    }
                   
                }
                else
                {
                    return false;
                }
                

            }
        }

        private void UpdatePersonLoginTime(int personID)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString())
            {
             string cmdText = "UPDATE Person SET LastLoginTime=@LastLoginTime WHERE PersonId=@personID;";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@LastLoginTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@personId", personID);
            conn.Open();
            cmd.ExecuteNonQuery();
            }
        }
    } // end class 
} // end namespace 
