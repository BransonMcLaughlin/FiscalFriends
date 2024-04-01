using FiscalFriendsBusiness;
using  FiscalFriendsWeb.Pages.LoginModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

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
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());
                String cmdText = "SELECT PasswordHash FROM [User] WHERE Email=@email;";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Email", loginUser.Email);
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
                            return RedirectToPage("Profile");
                        }
                        else
                        {
                            ModelState.AddModelError("LoginError", "Invalid Credentials, Try again.");
                            return Page();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid credentails. Try again.");
                }
                conn.Close();
                return RedirectToPage();
            }
            else
            {
                return Page();
            }
        } // end ActionResult
    } // end class 
} // end namespace 
