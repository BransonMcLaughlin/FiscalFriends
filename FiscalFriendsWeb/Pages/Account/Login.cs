using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.LoginModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace FiscalFriendsWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login loginUser { get; set; }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // check login credentials
                if(ValidateCredentials())
                {
                    
                    //if the credentials are valid redirect user to profile
                    return RedirectToPage("Profile");
                }
                else
                {
                    //else, display error
                    ModelState.AddModelError("LoginError", "Invalid Credentials, Try again.");
                    return Page();
                }
                
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
                String cmdText = "SELECT PasswordHash, PersonID, FirstName, Email " + 
                    " FROM [User] WHERE Username=@username;";
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
                            int personId = reader.GetInt32(1);
                            UpdatePersonLogInTime(personId);

                            //Create a principal
                            string name = reader.GetString(2);
                            string username = reader.GetString(4);
                            string email = reader.GetString(5);
                            

                            Claim emailClaim = new Claim(ClaimTypes.Email, loginUser.Email);

                            List<Claim> claims = new List<Claim> { emailClaim };

                            //Add the list of claims to a ClaimsIdentity
                            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            //Add the identity to a claims Principal
                            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                            //4. Call HttpContext.SigninAsync() method to encrypt
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme);


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

        private void UpdatePersonLogInTime(int personId)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE [User] Set LastLoggedIn=@LastLoggedIn WHERE PersonId=@personId";
                SqlCommand cmd = new SqlCommand( cmdText, conn);
                cmd.Parameters.AddWithValue("@LastLoggedIn", DateTime.Now);
                cmd.Parameters.AddWithValue("@personId", personId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    } // end class 
} // end namespace 