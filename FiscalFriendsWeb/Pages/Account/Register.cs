using FiscalFriendsWeb.Pages.UserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.Account
{
    public class Register : PageModel
    {
        [BindProperty]
        public User newUser {  get; set; }

        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //insert data into dataBase
                //1. Create a database connection string
                string conString = "Serve = (localdb)\\MSSQLLocalDB;Database=FiscalFriends;Trusted_Connection=true";
                SqlConnection con = new SqlConnection(conString);
                //2. Create a insert command
                string cmdText = "INSERT INTO user(FirstName, LastName, Email, PhoneNumber, UserName, Password, ZipCode, Birthday, AccountMadeDate, LastLoggedIn, ProfilePic)" +
                    "VALUES(@firsName, @lastName, @email, @phoneNumber, @userName, @password)";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@firstName", newUser.FirstName);
                cmd.Parameters.AddWithValue("@lastName", newUser.LastName);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", newUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@userName", newUser.userName);
                cmd.Parameters.AddWithValue("@lastLoggedIn", DateTime.Now.ToString());

                //3. open the database
                con.Open();
                //4. execute the command
                cmd.ExecuteNonQuery();

                //5. close the database
                con.Close();
                return RedirectToPage("Login");

            }
            return Page();
        }
    }
}
