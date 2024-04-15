using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using FiscalFriendsWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using FiscalFriendsBusiness;
using Microsoft.Data.SqlClient;

namespace FiscalFriendsWeb.Pages.DailyExpenses
{
    [BindProperties]
    public class AddDailyExpenseModel : PageModel
    {
        
        public DailyExpense newDailyExpense { get; set; } = new DailyExpense();

        // place holder for drop down
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateCategoryDDL();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO DailyExpenses(Amount, Description, PaymentMethod, Vendor, Date, Category)" +
                                              "VALUES(@amount, @description, @paymentMethod, @vendor, @date, @category)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@amount", newDailyExpense.amount);
                    cmd.Parameters.AddWithValue("@description", newDailyExpense.description);
                    cmd.Parameters.AddWithValue("@paymentMethod", newDailyExpense.paymentMethod);
                    cmd.Parameters.AddWithValue("@vendor", newDailyExpense.vendor);
                    if(newDailyExpense.date == DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@date", newDailyExpense.date);
                    }    
                    cmd.Parameters.AddWithValue("@category", newDailyExpense.Category);
                    //3. open the database
                    conn.Open();
                    //4. execute the command
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewDailyExpenses");
                }
            }
            else
            {
                return Page();
            }
        }

        private void PopulateCategoryDDL()
        {

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "SELECT CategoryId, CategoryDescription FROM ExpenseCategories";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read()) {
                        var Category = new SelectListItem();
                        Category.Value = reader.GetInt32(0).ToString();
                        Category.Text = reader.GetString(1);
                        Categories.Add(Category);
                    }
                }
            } 
        }
    }
}
