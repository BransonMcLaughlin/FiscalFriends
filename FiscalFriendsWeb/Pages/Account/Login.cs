using FiscalFriendsBusiness;
using FiscalFriendsWeb.Pages.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.Account
{
    public class Login : PageModel
    {
        [BindProperty]
        public User loginUser { get; set; }
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
                SqlConnection con = new SqlConnection(SecurityHelper.GetDBConnectionString());
                String cmdText = "SELECT Password, FirstName, LastName FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if(SecurityHelper.VerifyPassword(loginUser.Password, passwordHash))
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
                con.Close();
                return RedirectToPage();
            }
            else
            {
                return Page();
            }
        }
    }
}
